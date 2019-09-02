using Oculus.Newtonsoft.Json;
using System.Collections.Generic;

namespace SubnauticaResearchRequirements
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Settings
    {
        internal ScannerData ScannerData;

        public Dictionary<string, int> Blueprints = new Dictionary<string, int>();
        public string RecipeSeed;

        public static Settings Instance = new Settings();

        public void Initialize()
        {
            ScannerData = new ScannerData(Blueprints);
        }
    }
}
