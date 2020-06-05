using System;
using System.Collections.Generic;

namespace Gameplay.ExerciseMachine
{
    public struct MistakeCountStatistic
    {
        public int errors;
        public int correct;
    }

    public class MistakeCount : ExerciseMachine
    {
        // текст для печати
        public string Text { get; private set; }
        // набор текстов для печати. группировка по языку и по сложности
        private static Dictionary<Language, Dictionary<Difficulty, List<string>>> textsForLangs;

        public MistakeCount(Language lang, Difficulty difficulty)
        {
            if (textsForLangs == null)
                throw new Exception("Не хватает инициализации текстов");
            var rng = new Random();
            int cnt = textsForLangs[lang][difficulty].Count;

            Text = textsForLangs[lang][difficulty][rng.Next(cnt)];
        }

        /// <summary>
        /// Инициализация тренажера
        /// </summary>
        /// <param name="textsForLangs"></param>
        public static void Init(Dictionary<Language, Dictionary<Difficulty, List<string>>> textsForLangs)
        {
            MistakeCount.textsForLangs = textsForLangs;
        }

        public bool check(object statistic)
        {
            return false;
        }
    }
}
