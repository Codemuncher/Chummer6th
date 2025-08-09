using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using ChummerHub.Services.JwT;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace ChummerHub.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IActionContextAccessor _accessor;
        private readonly IConfiguration _configuration;

        public LoginModel(SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager, IActionContextAccessor accessor, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _accessor = accessor;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            if (_signInManager.IsSignedIn(User))
            {
                _logger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null)
                    user = await _userManager.FindByNameAsync(Input.Email);
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    //my code
                    JwtSecurityToken token = null;
                    IList<string> roles = new List<string>();
                    if (User != null)
                    {
                        if (user == null)
                            user = await _userManager.GetUserAsync(User);
                        if (user != null)
                            roles = await _userManager.GetRolesAsync(user);
                    }
                    var helper = new JwtHelper(_logger, _configuration);
                    token = helper.GenerateJwTSecurityToken(user, roles);
                    var claims = new List<Claim>();

                    foreach (var tokenClaim in token.Claims)
                    {
                        var claim = new Claim(tokenClaim.Type, tokenClaim.Value);
                        claims.Add(claim);
                    }

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, nameType, roleType);

                    var principal = new ClaimsPrincipal(identity);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = true,
                        ExpiresUtc = token.ValidTo,
                        IssuedUtc = DateTime.UtcNow
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        authProperties);

                    var redirectresult = new RedirectResult(returnUrl, true);
                    
                    redirectresult.UrlHelper = new UrlHelper(_accessor.ActionContext);

                    string returntoken = JwtHelper.GetJwtTokenString(token);

                    //returntoken = Convert.ToBase64String(Encoding.ASCII.GetBytes(returntoken));
                    string encheadertoken = System.Text.Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(returntoken)); //System.Web.HttpUtility.HtmlEncode(returntoken);

                    encheadertoken = Regex.Replace(encheadertoken, @"[^\u001F-\u007F]+", string.Empty);

                    var urlEncode = String.Join("/", returnUrl.Split("/").Select(s => System.Net.WebUtility.UrlEncode(s)), encheadertoken);

                    

                    if (!redirectresult.UrlHelper
                          .ActionContext
                          .HttpContext
                          .Response.Headers.TryAdd("Authorization", "Bearer " + encheadertoken))
                    {
                        _logger.LogWarning("Could not add Bearer to response!");
                    }

                    
                    redirectresult.UrlHelper
                          .ActionContext
                          .HttpContext
                          .Response.Redirect(urlEncode);

                    //redirectresult.UrlHelper
                    //      .ActionContext.HttpContext.Response.Cookies.Append("token", JwtHelper.GetJwtTokenString(token));
                    ////_sessionManager.SetString("token", response.Token);

                    HttpContext.User = principal;
                    redirectresult.UrlHelper
                          .ActionContext
                          .HttpContext.User = principal;

                    return redirectresult;
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private void HandleCookieLogin()
        {
          
        }
    }
}
