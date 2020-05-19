﻿using Gameplay;
using Gameplay.ExerciseMachine;
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
                        EventAction[] actions = new EventAction[3];
                        //создаем список действий для конкретного события
                        for (int p = 0; p < 3; ++p)
                        {
                            string event_action_descr = "#" + biom_str + i + "_" + 
                                                        object_str + j + "_" + 
                                                        event_str + k + "_" + 
                                                        event_action_str + p + descr_str;
                            ExerciseType type = ExerciseType.SYMBOL_STREAM + p;
                            actions[p] = new EventAction(event_action_descr, type);
                        }
                        events[k] = new Event(event_descr, actions);
                    }
                    string object_name = "#" + biom_str + i + "_" + object_str + j + name_str;
                    string object_descr = "#" + biom_str + i + "_" + object_str + j + descr_str;
                    objects[j] = new EventObject(object_name, object_descr, events);
                }
                string biom_name = "#" + biom_str + i + name_str;
                string biom_descr = "#" + biom_str + i + descr_str;
                bioms[i] = new Biom(biom_name, biom_descr, objects);
            }
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
