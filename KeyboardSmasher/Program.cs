using KeyboardSmasher.ExerciseMachine;
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

    static class Program
    {
        private static void Initilize()
        {
            
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main_form = new MainForm();
            main_form.showMainMenu();
            main_form.ShowDialog();
        }
    }
}
