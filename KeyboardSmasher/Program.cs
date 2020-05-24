using Gameplay;
using Gameplay.ExerciseMachine;
using KeyboardSmasher.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KeyboardSmasher
{
    

    static class Program
    {
        private static Dictionary<Language, string> localization_paths;

        private static Biom[] bioms;

        private static void Initialize()
        {
            #region localization
            localization_paths = new Dictionary<Language, string>();
            localization_paths.Add(Language.RUSSIAN, "russian.txt");
            localization_paths.Add(Language.ENGLISH, "english.txt");
            #endregion
            //bioms = DeserializeGameData("gamedata.xml");
            Localization.Localization default_loc = new Localization.Localization();
            //программное создание списка биомов
            bioms = new Biom[5];
            const string biom_str = "BIOM";
            const string name_str = "_NAME";
            const string descr_str = "_DESCRIPTION";
            const string object_str = "EVENT_OBJECT";
            const string event_str = "EVENT";
            const string event_action_str = "EVENT_ACTION";
            for(int i = 0; i < 5; ++i)
            {
                //создаем список объектов в конкретном биоме
                EventObject[] objects = new EventObject[10];
                for(int j = 0; j < 10; ++j)
                {
                    //создаем список событий для конкретного объекта
                    Event[] events = new Event[10];
                    for (int k = 0; k < 10; ++k)
                    { 
                        string event_descr = "#" + biom_str + i + "_" + object_str + j + "_" + event_str + k + descr_str;
                        default_loc.addTranslatedString(event_descr, "event_descr");
                        EventAction[] actions = new EventAction[3];
                        //создаем список действий для конкретного события
                        for (int p = 0; p < 3; ++p)
                        {
                            string event_action_descr = "#" + biom_str + i + "_" + 
                                                        object_str + j + "_" + 
                                                        event_str + k + "_" + 
                                                        event_action_str + p + descr_str;
                            default_loc.addTranslatedString(event_action_descr, "event_action_descr");
                            ExerciseType type = ExerciseType.SYMBOL_STREAM + p;
                            actions[p] = new EventAction(event_action_descr, type);
                        }
                        events[k] = new Event(event_descr, actions);
                    }
                    string object_name = "#" + biom_str + i + "_" + object_str + j + name_str;
                    string object_descr = "#" + biom_str + i + "_" + object_str + j + descr_str;
                    default_loc.addTranslatedString(object_name, "object_name");
                    default_loc.addTranslatedString(object_descr, "object_descr");
                    objects[j] = new EventObject(object_name, object_descr, events);
                }
                string biom_name = "#" + biom_str + i + name_str;
                string biom_descr = "#" + biom_str + i + descr_str;
                default_loc.addTranslatedString(biom_name, "biom_name");
                default_loc.addTranslatedString(biom_descr, "biom_descr");
                bioms[i] = new Biom(biom_name, biom_descr, objects);
            }

            Dictionary<Language, Dictionary<Difficulty, char[]>> symbol_sets = new Dictionary<Language, Dictionary<Difficulty, char[]>>();
            symbol_sets.Add(Language.RUSSIAN, new Dictionary<Difficulty, char[]>());
            char[] ss = { 'ф', 'ы', 'в', 'а', 'о', 'л', 'д', 'ж' };
            symbol_sets[Language.RUSSIAN].Add(Difficulty.EASY, ss);
            // ----Тест---
            symbol_sets[Language.RUSSIAN] = new Dictionary<Difficulty, char[]>();
            symbol_sets[Language.RUSSIAN][Difficulty.EASY] = 
                new char[] { 'й', 'ц', 'у', 'к', 'ф', 'ы', 'в', 'а', 'я', 'ч', 'с', 'м'};
            symbol_sets[Language.RUSSIAN][Difficulty.NORMAL] = 
                new char[] { 'у', 'к', 'е', 'н', 'г', 'в', 'а', 'п', 'р', 'о', 'с',  'м', 'и', 'т', 'ь'};
            symbol_sets[Language.RUSSIAN][Difficulty.HARD] =
                new char[] { 'й', 'ц', 'у', 'к', 'ф', 'ы', 'в', 'а', 'я', 'ч', 'с', 'м', 'е', 'н', 'г', 'ш', 'п', 
                    'р', 'о', 'л', 'и', 'т', 'ъ', 'х', 'з', 'щ', 'э', 'ж', 'д', 'ю', 'б', 'ь'};
            symbol_sets[Language.ENGLISH] = new Dictionary<Difficulty, char[]>();
            symbol_sets[Language.ENGLISH][Difficulty.EASY] =
                new char[] { 'q', 'w', 'e', 'r', 'a', 's', 'd', 'f', 'z', 'x', 'c', 'v' };
            symbol_sets[Language.ENGLISH][Difficulty.NORMAL] =
                new char[] { 'e', 'r', 't', 'y', 'u', 'd', 'f', 'g', 'h', 'j', 'c', 'v', 'b', 'n' };
            symbol_sets[Language.ENGLISH][Difficulty.HARD] =
                new char[] { 'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c', 'p', 'o', 'i', 'l', 'k', 'j', 'm', 'n',
                    'r', 't', 'y', 'u', 'f', 'g', 'h', 'v', 'b' };
            // ----Тест----
            SymbolStream.Init(symbol_sets);
        }

        private static Biom[] DeserializeGameData(string gamedata_path)
        {
            string json = File.ReadAllText(gamedata_path);
            return JsonConvert.DeserializeObject<Biom[]>(json);
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
