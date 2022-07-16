using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;

namespace AutoLoginTool
{
    public static class SteamLoginer
    {
        private static string steamPath = "";

        static SteamLoginer()
        {
            steamPath = GetSteamPath();
            DisableCredentialSaving();
        }

        public static void KillSteam()
        {
            var processes = Process.GetProcessesByName("steam");
            if (processes.Length == 0)
                return;

            var process = processes[0];
            process.Kill();
            process.WaitForExit();
            process.Dispose();
        }

        private static string GetSteamPath()
        {
            if (steamPath.Length > 0)
            {
                return steamPath;
            }

            steamPath = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Valve\\Steam", "InstallPath", "");

            if (steamPath.Length == 0)
            {
                MessageBox.Show("Cannot find steam path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return steamPath;
        }

        private static void DisableCredentialSaving()
        {
            string configDir = GetSteamPath() + "\\config\\config.vdf";

            string configTxt = File.ReadAllText(configDir);

            configTxt = configTxt.Replace("\"NoSavePersonalInfo\"\t\t\"0\"", "\"NoSavePersonalInfo\"\t\t\"1\"");

            File.WriteAllText(configDir, configTxt);
        }

        public static void Login(string user = null, string pass = null)
        {
            string steamFile = GetSteamPath() + "\\steam.exe";
            string startCommand = "";

            if (user != null && pass != null)
            {
                startCommand += $"-login {Regex.Escape(user)} {Regex.Escape(pass)}";
            }

            Process.Start(steamFile, startCommand);
        }
    }
}
