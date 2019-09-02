using Harmony;
using Oculus.Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace SubnauticaResearchRequirements
{
    public class QPatch
    {
        public static void Patch()
        {
            ManageSettingsFile();

            HarmonyInstance harmony = HarmonyInstance.Create("theah.subnauticaresearch");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static string GetModDirectory()
        {
            string modDirectory = Path.Combine(Environment.CurrentDirectory, "QMods");
            return Path.Combine(modDirectory, "SubnauticaResearchRequirements");
        }

        private static void ManageSettingsFile()
        {
            string settingsPath = Path.Combine(GetModDirectory(), "config.json");

            if (File.Exists(settingsPath))
            {
                try
                {
                    Settings.Instance = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsPath));
                }
                catch(Exception ex)
                {
                    LogError("Error parsing config.json");
                    LogError(ex.ToString());
                    Settings.Instance = new Settings();
                }
            }
            else
            {
                Settings.Instance = new Settings();
            }

            Settings.Instance.Initialize();
        }

        public static void LogError(string text)
        {
            var logFile = Path.Combine(GetModDirectory(), "log.txt");
            File.AppendAllText(logFile, "\r\n" + text);
        }
    }
}
