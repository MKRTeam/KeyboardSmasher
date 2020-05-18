using Gameplay;
using KeyboardSmasher.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KeyboardSmasher
{
    public enum Language
    {
        RUSSIAN,
        ENGLISH
    }

    static class Program
    {
        private static Dictionary<Language, string> localization_paths;
        [XmlElement]
        private static Biom[] bioms;
        private static void Initialize()
        {
            #region localization
            localization_paths = new Dictionary<Language, string>();
            localization_paths.Add(Language.RUSSIAN, "russian.xml");
            localization_paths.Add(Language.ENGLISH, "english.xml");
            #endregion
            //bioms = DeserializeGameData("gamedata.xml");
        }

        private static Biom[] DeserializeGameData(string gamedata_path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Biom[]));
            using (Stream reader = new FileStream(gamedata_path, FileMode.Open))
            {
                return (Biom[])serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main_form = new MainForm(localization_paths, bioms);
            main_form.showMainMenu();
            main_form.ShowDialog();
        }
    }
}
