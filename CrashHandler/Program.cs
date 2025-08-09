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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Chummer;

[assembly: CLSCompliant(true)]

namespace CrashHandler
{
    internal static class Program
    {
        private static readonly Dictionary<string, Action<string[]>> s_DictionaryFunctions =
            new Dictionary<string, Action<string[]>>
            {
                {"crash", ShowCrashReport}
            };

        private static void ShowCrashReport(string[] args)
        {
            using (CrashDumper objDumper = new CrashDumper(args[0], args[1]))
            {
                Application.Run(new CrashReporter(objDumper));
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Chummer.Program.SetProcessDPI(GlobalSettings.DpiScalingMethodSetting);
            if (Chummer.Program.IsMainThread)
                Chummer.Program.SetThreadDPI(GlobalSettings.DpiScalingMethodSetting);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int intDebugArgIndex = -1;
            for (int i = 0; i < args.Length - 1; ++i)
            {
                if (args[i].Equals("--debug", StringComparison.OrdinalIgnoreCase))
                {
                    if (!Debugger.IsAttached)
                        Debugger.Launch();
                    intDebugArgIndex = i;
                    break;
                }
            }

            if (intDebugArgIndex >= 0)
            {
                string[] astrNewArgs = new string[args.Length - 1];
                for (int i = 0; i < args.Length - 1; ++i)
                {
                    if (i == intDebugArgIndex)
                        continue;
                    if (i > intDebugArgIndex)
                        astrNewArgs[i - 1] = args[i];
                    else
                        astrNewArgs[i] = args[i];
                }
                args = astrNewArgs;
            }

            for (int i = 0; i < args.Length - 1; ++i)
            {
                if (s_DictionaryFunctions.TryGetValue(args[i], out Action<string[]> actCachedAction))
                {
                    actCachedAction(args.Skip(i + 1).ToArray());
                    break;
                }
            }
        }
    }
}
