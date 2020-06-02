using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static Dictionary<Language, Dictionary<Difficulty, string>> textsForLangs;

        public MistakeCount(Language lang, Difficulty difficulty)
        {
            if (textsForLangs == null)
                throw new Exception("Не хватает инициализации текстов");

            Text = textsForLangs[lang][difficulty];
        }

        public static void Init(Dictionary<Language, Dictionary<Difficulty, string>> textsForLangs)
        {
            MistakeCount.textsForLangs = textsForLangs;
        }

        public bool check(object statistic)
        {
            return false;
        }
    }
}
