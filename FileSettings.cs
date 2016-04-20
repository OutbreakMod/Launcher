using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutbreakLauncher
{
    class FileSettings
    {
        private static Dictionary<String, String> KeyValueSettings;

        static FileSettings()
        {
            KeyValueSettings = new Dictionary<string, string>();
        }          

        public static string GetValue(string Key)
        {
            if (KeyValueSettings.ContainsKey(Key))
            {
                return KeyValueSettings[Key];
            }

            return string.Empty;
        }

        public static void SetValue(string Key, string Value)
        {
            if (KeyValueSettings.ContainsKey(Key))
            {
                KeyValueSettings[Key] = Key;
            }
            else
            {
                KeyValueSettings.Add(Key, Value);
            }
        }
    }
}
