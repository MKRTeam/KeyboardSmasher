using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
{
    public struct WordsOnReactionStatistic
    {

    }

    class WordsOnReaction : ExerciseMachine
    {
        //текст, который дадим писать пользователю
        public string Text { get; }

        //Время на все испытание
        public TimeSpan Time { get; }

        /// <summary>
        /// Levenstein Distance is a string metric, returns a number of edits
        /// needs to be done to turn the first string into the second
        /// </summary>
        /// <param name="first_str"></param>
        /// <param name="second_str"></param>
        /// <returns></returns>
        public static int LDistance(string first_str, string second_str) {
            int n = first_str.Length;
            int m = second_str.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0) {
                return m;
            }
            if (m == 0) {
                return n;
            }

            for (int i = 0; i <= n; d[i, 0] = i++) {}
            for (int j = 0; j <= m; d[0, j] = j++) {}

            for (int i = 1; i <= n; i++) {
                for (int j = 1; j <= m; j++) {
                    int cost = (second_str[j - 1] == first_str[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
        public WordsOnReaction(Difficulty difficulty)
        {
            Text = @"Сухогруз Скадовск - место безопасное,
                с выходом в космос. Это завод старых зафрахтованных 
                ракет на консервации.
                Скадовск расположен как раз над морским фарватером, 
                в его устье есть площадка с горным тоннелем метро.";
            Time = TimeSpan.FromSeconds(30.0);
        }

        public bool check(object statistic)
        {
            return false;
        }
    }
}
