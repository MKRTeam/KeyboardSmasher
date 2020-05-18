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
        
        private static void Initialize()
        {
            localization_paths = new Dictionary<Language, string>();
            localization_paths.Add(Language.RUSSIAN, "russian.xml");
            localization_paths.Add(Language.ENGLISH, "english.xml");
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
            MainForm main_form = new MainForm(localization_paths);
            main_form.showMainMenu();
            main_form.ShowDialog();
        }
    }
}
