using KeyboardSmasher.ExerciseMachine;
using KeyboardSmasher.Gameplay;
using KeyboardSmasher.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher
{
    //типа тренажеров
    public enum ExerciseType
    {
        NO_EXERCISE,
        SYMBOL_STREAM,
        WORDS_ON_REACTION,
        MISTAKE_COUNT
    }

    //уровни сложности
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    public enum Language
    {
        RUSSIAN,
        ENGLISH
    }

    static class Program
    {
        private static Dictionary<Language, string> localization_paths;
        private static Biom[] bioms;
        private static int bioms_count = 1;
        private static void Initialize()
        {
            #region localization
            localization_paths = new Dictionary<Language, string>();
            localization_paths.Add(Language.RUSSIAN, "russian.xml");
            localization_paths.Add(Language.ENGLISH, "english.xml");
            #endregion
            #region bioms
            bioms = new Biom[bioms_count];
            #region biom1
            const int objects_count = 5;
            EventObject[] objects = new EventObject[objects_count];
            bioms[0] = new Biom("Тайга", "Описание", objects);
            #endregion
            #endregion
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
