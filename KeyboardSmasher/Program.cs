using KeyboardSmasher.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher
{
    //типа тренажеров
    enum ExerciseType
    {
        NO_EXERCISE,
        SYMBOL_STREAM,
        WORDS_ON_REACTION,
        MISTAKE_COUNT
    }

    //уровни сложности
    enum Difficulty
    {
        EASY,
        NORMAL,
        HIGH
    }

    static class Program
    {
        //список тренажеров
        private static Dictionary<ExerciseType, ExerciseMachine.ExerciseMachine> machines = null;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //здесь происходит загрузка всех ресурсов

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
