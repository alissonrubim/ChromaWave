using ChromaWave.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaWave.Controller
{
    public class SettingsController
    {
        private static string pSettingFilePath = "settings.cfg";

        public static Settings Load()
        {
            if (File.Exists(pSettingFilePath))
            {
                using (StreamReader reader = new StreamReader(pSettingFilePath))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Settings>(json);
                }
            }
            else
            {
                Save(new Settings());
                return Load();
            }
        }

        public static void Save(Settings settings)
        {
            using (StreamWriter writer = new StreamWriter(pSettingFilePath))
            {
                writer.Write(JsonConvert.SerializeObject(settings));
            }
        }
    }
}
