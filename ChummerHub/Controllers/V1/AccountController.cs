/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */
using ChummerHub.API;
using ChummerHub.Data;
using ChummerHub.Models.V1;
using ChummerHub.Models.V1.Examples;
using ChummerHub.Services.JwT;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace ChummerHub.Controllers
{
    [Route("api/v{api-version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly TelemetryClient tc;

        public AccountController(ApplicationDbContext context,
            ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            TelemetryClient telemetry)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            tc = telemetry;
        }

        /// <summary>
        /// This is only a sample-Implementation, Authentication should be handeld via the login-page and the cookie (only with a different redirect)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost]
        public async Task<string> Authenticate()
        {
            string tokenstring = null;
            ApplicationUser user = null;
            JwtSecurityToken token = null;
            IList<string> roles = new List<string>();
            if (User != null)
            {
                user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
                roles = await _userManager.GetRolesAsync(user);
            }
            tokenstring = await getBearerToken(user, roles);
            return tokenstring;
        }

        private async Task<string> getBearerToken(ApplicationUser user, IList<string> roles)
        {
            var helper = new JwtHelper(_logger, _configuration);
            var token = helper.GenerateJwTSecurityToken(user, roles);
            if (User != null)
            {
                // also add cookie auth for Swagger Access
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.IsPersistent, true.ToString()));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    });
            }
            //return the token to API client
            string tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenstring;
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetPossibleRoles")]
        [Authorize(Roles = API.Authorization.Constants.UserRolePublicAccess, AuthenticationSchemes = "JWT_OR_COOKIE")]
        //[Authorize(Roles = Authorizarion.Constants.UserRolePublicAccess, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResultAccountGetPossibleRoles>> GetPossibleRoles()
        {
            ResultAccountGetPossibleRoles res;
            try
            {
                var list = await _context.Roles.Select(a => a.Name).ToListAsync();
                res = new ResultAccountGetPossibleRoles(list);
                return Ok(res);
            }
            catch (Exception e)
            {
                res = new ResultAccountGetPossibleRoles(e);
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetRoles")]
        [Authorize(Roles = API.Authorization.Constants.UserRolePublicAccess, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResultAccountGetRoles>> GetRoles()
        {
            ResultAccountGetRoles res;
            try
            {
                ApplicationUser user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
                //var user = await _signInManager.UserManager.GetUserAsync(User);
                if (user.EmailConfirmed)
                {
                    await SeedData.EnsureRole(Program.MyHost.Services, user.Id, API.Authorization.Constants.UserRoleConfirmed, _roleManager, _userManager);
                }
                var roles = await _userManager.GetRolesAsync(user);
                var list = await _context.Roles.Select(a => a.Name).ToListAsync();
                res = new ResultAccountGetRoles(roles, list);

                return Ok(res);
            }
            catch (Exception e)
            {
                res = new ResultAccountGetRoles(e);
                return BadRequest(res);
            }
        }

        //[HttpGet]
        //[Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        //[Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        //[Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        //[Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetUserByEmail")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        //public async Task<ActionResult<ResultAccountGetUserByEmail>> GetUserByEmail(string email)
        //{
        //    ResultAccountGetUserByEmail res;
        //    try
        //    {
        //        ApplicationUser user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
        //        res = new ResultAccountGetUserByEmail(user);
        //        if (user == null)
        //            return NotFound(res);
        //        user.PasswordHash = string.Empty;
        //        user.SecurityStamp = string.Empty;
        //        return Ok(res);
        //    }
        //    catch (Exception e)
        //    {
        //        res = new ResultAccountGetUserByEmail(e);
        //        return BadRequest(res);
        //    }
        //}

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Conflict)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("GetAddSqlDbUser")]
        [Authorize(Roles = API.Authorization.Constants.UserRoleAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetAddSqlDbUser(string username, string password, string start_ip_address, string end_ip_address)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new ArgumentNullException(nameof(username));
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException(nameof(password));

                IPAddress startaddress = null;
                if (!string.IsNullOrEmpty(start_ip_address))
                {
                    startaddress = IPAddress.Parse(start_ip_address);
                }
                IPAddress endaddress = null;
                if (!string.IsNullOrEmpty(end_ip_address))
                {
                    endaddress = IPAddress.Parse(end_ip_address);
                }
                if (string.IsNullOrEmpty(Startup.ConnectionStringToMasterSqlDb))
                {
                    throw new ArgumentNullException(nameof(Startup.ConnectionStringToMasterSqlDb));
                }


                try
                {
                    string cmd = "CREATE LOGIN " + username + " WITH password = '" + password + "';";
                    using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringToMasterSqlDb))
                    {
                        await masterConnection.OpenAsync();
                        using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e)
                {
                    result += e.Message + Environment.NewLine + Environment.NewLine;
                }
                //create the user in the master DB
                try
                {
                    string cmd = "CREATE USER " + username + " FROM LOGIN " + username + ";";
                    using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringToMasterSqlDb))
                    {
                        await masterConnection.OpenAsync();
                        using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e)
                {
                    result += e.Message + Environment.NewLine + Environment.NewLine;
                }
                //create the user in the sinner_db as well!
                try
                {
                    string cmd = "CREATE USER " + username + " FROM LOGIN " + username + ";";
                    using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringSinnersDb))
                    {
                        await masterConnection.OpenAsync();
                        using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    result += e.Message + Environment.NewLine + Environment.NewLine;
                }
                try
                {
                    string cmd = "ALTER ROLE dbmanager ADD MEMBER " + username + ";";
                    using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringSinnersDb))
                    {
                        await masterConnection.OpenAsync();
                        using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    bool worked = false;
                    try
                    {
                        string cmd = "EXEC sp_addrolemember 'db_owner', '" + username + "';";
                        using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringSinnersDb))
                        {
                            await masterConnection.OpenAsync();
                            using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                            {
                                dbcmd.ExecuteNonQuery();
                            }
                        }
                        worked = true;
                    }
                    catch (Exception e1)
                    {
                        result += e1 + Environment.NewLine + Environment.NewLine;
                    }
                    if (worked)
                    {
                        result += "User added!" + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        result += e.Message + Environment.NewLine + Environment.NewLine;
                    }
                }
                try
                {
                    string cmd = "EXEC sp_set_database_firewall_rule N'Allow " +
                                 username + "', '" + startaddress + "', '" + endaddress + "';";
                    using (SqlConnection masterConnection = new SqlConnection(Startup.ConnectionStringSinnersDb))
                    {
                        await masterConnection.OpenAsync();
                        using (SqlCommand dbcmd = new SqlCommand(cmd, masterConnection))
                        {
                            dbcmd.ExecuteNonQuery();
                        }

                        result += "Firewallrule added: " + startaddress + " - " + endaddress + Environment.NewLine +
                                  Environment.NewLine;
                    }
                }
                catch (Exception e)
                {
                    result += e.Message + Environment.NewLine + Environment.NewLine;
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity.Name);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                result += Environment.NewLine + e;
                if (e is HubException)
                    return BadRequest(e);
                HubException hue = new HubException(result, e);
                return BadRequest(hue);
            }
        }

        [HttpPost]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("PostSetUserRole")]
        [Authorize(Roles = API.Authorization.Constants.UserRoleAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ApplicationUser>> PostSetUserRole(string email, string userrole)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return NotFound();
                await SeedData.EnsureRole(Program.MyHost.Services, user.Id, userrole, _roleManager, _userManager);
                user.PasswordHash = string.Empty;
                user.SecurityStamp = string.Empty;
                return Ok(user);
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                if (e is HubException)
                    return BadRequest(e);
                HubException hue = new HubException(e.Message, e);
                return BadRequest(hue);
            }
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK, "LogonUser", typeof(ResultAccountGetUserByAuthorization))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.NotFound, "LogonUser", typeof(ResultAccountGetUserByAuthorization))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest, "LogonUser", typeof(ResultAccountGetUserByAuthorization))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetUserByAuthorization")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResultAccountGetUserByAuthorization>> GetUserByAuthorization()
        {
            ResultAccountGetUserByAuthorization res;
            try
            {
                ApplicationUser user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
                res = new ResultAccountGetUserByAuthorization(user);
                if (user == null)
                    return NotFound(res);

                res.MyApplicationUser.PasswordHash = string.Empty;
                res.MyApplicationUser.SecurityStamp = string.Empty;
                return res;
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                res = new ResultAccountGetUserByAuthorization(e);
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("ResetDb")]
        [Authorize(Roles = API.Authorization.Constants.UserRoleAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetDeleteAllSINnersDb()
        {
            try
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                if (user == null)
                    return Unauthorized();
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Administrator"))
                    return Unauthorized();
                var count = await _context.SINners.CountAsync();
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    _context.UserRights.RemoveRange(await _context.UserRights.ToListAsync());
                    _context.SINnerComments.RemoveRange(await _context.SINnerComments.ToListAsync());
                    _context.Tags.RemoveRange(await _context.Tags.ToListAsync());
                    _context.SINnerVisibility.RemoveRange(await _context.SINnerVisibility.ToListAsync());
                    _context.SINnerMetaData.RemoveRange(await _context.SINnerMetaData.ToListAsync());
                    _context.SINners.RemoveRange(await _context.SINners.ToListAsync());
                    _context.UploadClients.RemoveRange(await _context.UploadClients.ToListAsync());

                    await _context.SaveChangesAsync();
                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    await transaction.CommitAsync();
                }
                return Ok("Reseted " + count + " SINners");
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                if (e is HubException)
                    return BadRequest(e);
                HubException hue = new HubException(e.Message, e);
                return BadRequest(hue);
            }
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("DeleteAndRecreate")]
        [Authorize(Roles = API.Authorization.Constants.UserRoleAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> GetDeleteAndRecreateDb()
        {
            try
            {
#if DEBUG
                Trace.TraceInformation("Users is NOT checked in Debug!");
#else
                var user = await _signInManager.UserManager.GetUserAsync(User);
                if(user == null)
                    return Unauthorized();
                var roles = await _userManager.GetRolesAsync(user);
                if(!roles.Contains("Administrator"))
                    return Unauthorized();
#endif
                await _context.Database.EnsureDeletedAsync();
                Startup.Seed(null);
                return Ok("Database recreated");
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                if (e is HubException)
                    return BadRequest(e);
                HubException hue = new HubException(e.Message, e);
                return BadRequest(hue);
            }
        }

        /// <summary>
        /// Search for Sinners for one user
        /// </summary>
        /// <returns>SINSearchGroupResult</returns>
        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetSinnersByAuthorization")]
        [Authorize(Roles = API.Authorization.Constants.UserRoleRegistered, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResultAccountGetSinnersByAuthorization>> GetSINnersByAuthorization()
        {
            try
            {
                var res = await GetSINnersByAuthorizationInternal(null);
                return res;
            }
            catch (Exception e)
            {
                ResultAccountGetSinnersByAuthorization error = new ResultAccountGetSinnersByAuthorization(e);
                return error;
            }
        }

        /// <summary>
        /// Search for Sinners for one user
        /// </summary>
        /// <returns>SINSearchGroupResult</returns>
        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetSinnersByToken")]
        [AllowAnonymous]
        //[Authorize(Roles = API.Authorization.Constants.UserRoleRegistered, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResultAccountGetSinnersByAuthorization>> GetSINnersByToken(string token)
        {
            try
            {
                var res = await GetSINnersByAuthorizationInternal(token);
                return res;
            }
            catch (Exception e)
            {
                ResultAccountGetSinnersByAuthorization error = new ResultAccountGetSinnersByAuthorization(e);
                return error;
            }
        }



        private async Task<ActionResult<ResultAccountGetSinnersByAuthorization>> GetSINnersByAuthorizationInternal(string token)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
            ResultAccountGetSinnersByAuthorization res = null;

            SINSearchGroupResult ret = new SINSearchGroupResult();
            res = new ResultAccountGetSinnersByAuthorization(ret);
            SINnerGroup sg = new SINnerGroup();
            ApplicationUser user = null;
            if (String.IsNullOrEmpty(token))
            {
                user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
            }
            else
            {
                JwtSecurityTokenHandler jwtSecurityToken = new JwtSecurityTokenHandler();
                TokenValidationParameters param = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                   
                };
                SecurityToken secToken;
                try
                {
                    var claims = jwtSecurityToken.ValidateToken(token, param, out secToken);
                }
                catch(Exception e)
                {
                    _logger.LogWarning("Token not validated: " + e.Message);
                    res = new ResultAccountGetSinnersByAuthorization(e)
                    {
                        ErrorText = "Unauthorized"
                    };
                    return BadRequest(res);
                }
                var jwtToken = jwtSecurityToken.ReadJwtToken(token);
                
                var name = jwtToken.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
                if (String.IsNullOrEmpty(name))
                    name = jwtToken.Subject;
                user = await _userManager.FindByNameAsync(name);
            }
            if (user == null)
            {
                var e = new AuthenticationException("User is not authenticated.");
                res = new ResultAccountGetSinnersByAuthorization(e)
                {
                    ErrorText = "Unauthorized"
                };
                return BadRequest(res);
            }
            IList<string> roles = new List<string>();
            if (user == null && User != null)
            {
                user = await JwtHelper.GetApplicationUserAsync(User, _userManager);
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
            }
            roles = await _userManager.GetRolesAsync(user);
            res.BearerToken = await getBearerToken(user, roles);
          
            res.UserEmail = user.Email;
            user.FavoriteGroups = user.FavoriteGroups.GroupBy(a => a.FavoriteGuid).Select(b => b.First()).ToList();

            SINnerSearchGroup ssg = new SINnerSearchGroup(sg, user)
            {
                MyMembers = new List<SINnerSearchGroupMember>()
            };

            using (var t = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                }, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //var roles = await _userManager.GetRolesAsync(user);
                    ret.Roles = roles.ToList();
                    ssg.Groupname = user.UserName;
                    ssg.Id = Guid.Empty;
                    var worklist = user.FavoriteGroups.Select(a => a.FavoriteGuid).ToList();
                    var groupworklist = await _context.SINnerGroups
                        .Include(a => a.MyGroups)
                        .ThenInclude(b => b.MyGroups)
                        .ThenInclude(c => c.MyGroups)
                        .ThenInclude(d => d.MyGroups)
                        .Where(a => a.Id != null && worklist.Contains(a.Id.Value)).ToListAsync();
                    ssg.MySINSearchGroups = await RecursiveBuildGroupMembers(groupworklist, user);
                    var memberworklist = _context.SINners
                        .Include(a => a.MyGroup)
                        .Include(a => a.SINnerMetaData.Visibility)
                        .Where(a => a.Id != null && worklist.Contains(a.Id.Value));
                    foreach (var member in memberworklist)
                    {
                        if (member.SINnerMetaData?.Visibility?.IsGroupVisible == false)
                        {
                            if (member.SINnerMetaData?.Visibility.UserRights.Any(a =>
                                    !string.IsNullOrEmpty(a.EMail)) == true)
                            {
                                if (member.SINnerMetaData?.Visibility.UserRights.Any(a =>
                                    user.NormalizedEmail.Equals(a.EMail, StringComparison.OrdinalIgnoreCase)) == false)
                                {
                                    //dont show this guy!
                                    continue;
                                }
                            }
                        }

                        member.LastDownload = DateTime.Now;
                        if (member.MyGroup == null)
                            member.MyGroup = new SINnerGroup();
                        if (member.MyGroup.MyGroups == null)
                            member.MyGroup.MyGroups = new List<SINnerGroup>();
                        SINnerSearchGroupMember sinssgGroupMember = new SINnerSearchGroupMember(user, member)
                        {
                            MySINner = member
                        };
                        ssg.MyMembers.Add(sinssgGroupMember);
                    }

                    await _context.SaveChangesAsync();
                    ret.SINGroups.Add(ssg);
                    res.MySINSearchGroupResult = ret;
                    return Ok(res);
                }
                catch (Exception e)
                {
                    try
                    {
                        await _signInManager.UserManager.GetUserAsync(User);
                        ExceptionTelemetry et = new ExceptionTelemetry(e);
                        et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                        tc.TrackException(et);
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex.ToString());
                    }

                    res = new ResultAccountGetSinnersByAuthorization(e);
                    return BadRequest(res);
                }
                finally
                {
                    AvailabilityTelemetry telemetry = new AvailabilityTelemetry("GetSINnersByAuthorization", DateTimeOffset.Now, sw.Elapsed, "Azure", res.CallSuccess, res.ErrorText);
                    tc?.TrackAvailability(telemetry);
                }
            }
        }

        private async Task<List<SINnerSearchGroup>> RecursiveBuildGroupMembers(IEnumerable<SINnerGroup> groupworklist, ApplicationUser user)
        {
            List<SINnerSearchGroup> addlist = new List<SINnerSearchGroup>();
            foreach (var singroup in groupworklist.ToList())
            {
                if (singroup == null)
                    continue;
                SINnerSearchGroup ssgFromSIN = addlist.FirstOrDefault(a => a.Id != null && a.Id == singroup.Id);
                if (ssgFromSIN == null)
                {
                    if (singroup.Id == null)
                    {
                        _context.SINnerGroups.Remove(singroup);
                        continue;
                    }
                    ssgFromSIN = new SINnerSearchGroup(singroup, user);
                    addlist.Add(ssgFromSIN);
                    //for all groups in this group
                    ssgFromSIN.MySINSearchGroups = await RecursiveBuildGroupMembers(singroup.MyGroups, user);
                }

                //add all members of his group
                var members = await singroup.GetGroupMembers(_context, false);
                foreach (var member in members)
                {
                    if (singroup.IsPublic != true)
                    {
                        if (member.SINnerMetaData?.Visibility?.IsGroupVisible == false)
                        {
                            if (member.SINnerMetaData?.Visibility.UserRights.Any(a =>
                                    string.IsNullOrEmpty(a.EMail) == false) == true)
                            {
                                if (member.SINnerMetaData?.Visibility.UserRights.Any(a =>
                                        a.EMail?.ToUpperInvariant() == user.NormalizedEmail) == false)
                                {
                                    //dont show this guy!
                                    continue;
                                }
                            }
                        }
                    }

                    member.LastDownload = DateTime.Now;
                    member.MyGroup = singroup;
                    member.MyGroup.MyGroups = new List<SINnerGroup>();
                    SINnerSearchGroupMember sinssgGroupMember = new SINnerSearchGroupMember(user, member)
                    {
                        MySINner = member
                    };
                    //check if it is already added:
                    if (ssgFromSIN.MyMembers.Any(a => a.MySINner == member))
                        continue;
                    ssgFromSIN.MyMembers.Add(sinssgGroupMember);
                }

                singroup.PasswordHash = string.Empty;
                singroup.MyGroups = new List<SINnerGroup>();
            }

            return addlist;
        }


        // GET: api/ChummerFiles
        [HttpGet]
        [Authorize(Roles = API.Authorization.Constants.UserRoleAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.NotFound)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.NoContent)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountGetSinnerAsAdmin")]
        public async Task<ActionResult<ResultGroupGetSearchGroups>> GetSinnerAsAdmin()
        {
            SINSearchGroupResult ret = new SINSearchGroupResult();
            ResultAccountGetSinnersByAuthorization res = new ResultAccountGetSinnersByAuthorization(ret);
            SINnerGroup sg = new SINnerGroup();
            var user = await _signInManager.UserManager.GetUserAsync(User);

            if (user == null)
            {
                var e = new AuthenticationException("User is not authenticated.");
                res = new ResultAccountGetSinnersByAuthorization(e)
                {
                    ErrorText = "Unauthorized"
                };
                return BadRequest(res);
            }
            res.UserEmail = user.Email;
            user.FavoriteGroups = user.FavoriteGroups.GroupBy(a => a.FavoriteGuid).Select(b => b.First()).ToList();

            SINnerSearchGroup ssg = new SINnerSearchGroup(sg, user)
            {
                MyMembers = new List<SINnerSearchGroupMember>()
            };
            try
            {
                var roles = await _userManager.GetRolesAsync(user);
                ret.Roles = roles.ToList();
                ssg.Groupname = user.Email;
                ssg.Id = Guid.Empty;
                //get all from visibility
                List<SINner> mySinners = await _context.SINners.Include(a => a.MyGroup)
                    .Include(a => a.SINnerMetaData.Visibility.UserRights)
                    .OrderByDescending(a => a.UploadDateTime)
                    .Take(200)
                    .ToListAsync();
                foreach (var sin in mySinners)
                {
                    SINnerSearchGroupMember ssgm = new SINnerSearchGroupMember(user, sin);
                    ssg.MyMembers.Add(ssgm);
                    if (sin.MyGroup != null)
                    {
                        SINnerSearchGroup ssgFromSIN = ssg.MySINSearchGroups.FirstOrDefault(a => a.Id == sin.MyGroup.Id);
                        if (ssgFromSIN == null)
                        {
                            ssgFromSIN = new SINnerSearchGroup(sin.MyGroup, user);
                            ssg.MySINSearchGroups.Add(ssgFromSIN);
                        }
                        //add all members of his group
                        var members = await sin.MyGroup.GetGroupMembers(_context, false);
                        foreach (var member in members)
                        {
                            member.MyGroup = sin.MyGroup;
                            member.MyGroup.MyGroups = new List<SINnerGroup>();
                            SINnerSearchGroupMember sinssgGroupMember = new SINnerSearchGroupMember(user, member);
                            ssgFromSIN.MyMembers.Add(sinssgGroupMember);
                        }
                        sin.MyGroup.PasswordHash = string.Empty;
                        sin.MyGroup.MyGroups = new List<SINnerGroup>();

                    }
                }

                ret.SINGroups.Add(ssg);
                res = new ResultAccountGetSinnersByAuthorization(ret);
                return Ok(res);
            }
            catch (Exception e)
            {
                try
                {
                    await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                res = new ResultAccountGetSinnersByAuthorization(e);
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.OK)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("AccountLogout")]
        [Authorize(Roles = API.Authorization.Constants.UserRolePublicAccess, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> Logout()
        {
            try
            {
                //var user = _userManager.FindByEmailAsync(email).Result;
                //var user = await _signInManager.UserManager.GetUserAsync(User);
                await _signInManager.SignOutAsync();
                return Ok(true);
            }
            catch (Exception e)
            {
                try
                {
                    var user = await _signInManager.UserManager.GetUserAsync(User);
                    //var tc = new Microsoft.ApplicationInsights.TelemetryClient();
                    ExceptionTelemetry et = new ExceptionTelemetry(e);
                    et.Properties.Add("user", User.Identity?.Name ?? string.Empty);
                    tc.TrackException(et);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex.ToString());
                }
                if (e is HubException)
                    return BadRequest(e);
                HubException hue = new HubException(e.Message, e);
                return BadRequest(hue);
            }
        }






    }
}
