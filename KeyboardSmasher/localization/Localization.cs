using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KeyboardSmasher.Localization
{
    class MyContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }

    [Serializable]
    public class Localization
    {
        Dictionary<string, string> localization;

        public Localization()
        {
            localization = new Dictionary<string, string>();
        }

        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = new MyContractResolver(),
            Formatting = Formatting.Indented
        };

        public static Localization Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            return (Localization)JsonConvert.DeserializeObject(json, settings);
        }

        public static void Serialize(Localization localization, string path)
        {
            string json = JsonConvert.SerializeObject(localization, settings);
            File.WriteAllText(path, json);
        }

        public string getTranslatedString(string string_id)
        {
            if (!localization.ContainsKey(string_id))
                return null;
            return localization[string_id];
        }

        public void addTranslatedString(string string_id, string translated_string)
        {
            localization.Add(string_id, translated_string);
        }
    }
}
