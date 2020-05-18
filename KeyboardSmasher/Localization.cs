using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KeyboardSmasher.localization
{
    public class Localization
    {
        [XmlElement]
        Dictionary<string, string> localization;

        public Localization()
        {
            localization = new Dictionary<string, string>();
        }

        public static Localization Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Localization));
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                return (Localization)serializer.Deserialize(reader);
            }
        }

        public static void Serialize(Localization localization, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Localization));
            using (Stream writer = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(writer, localization);
            }
        }

        public string getTranslatedString(string string_id)
        {
            return localization[string_id];
        }

        public void addTranslatedString(string string_id, string translated_string)
        {
            localization.Add(string_id, translated_string);
        }
    }
}
