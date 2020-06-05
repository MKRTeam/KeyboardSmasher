using System;

namespace Gameplay.ExerciseMachine
{
    public struct WordsOnReactionStatistic
    {
        public int identity_percents;
    }

    public class WordsOnReaction : ExerciseMachine
    {
        //текст, который дадим писать пользователю
        /// <summary>
        /// text for user to print
        /// </summary>
        public string Text { get; }

        private static string[] textsForExercise;

        /// <summary>
        /// exercise time
        /// </summary>
        public TimeSpan Time { get; }

        public static void Init() {
            textsForExercise = new string[6] {
            "Сухогруз Скадовск - место безопасное, с выходом в космос. " +
            "Это завод старых зафрахтованных ракет на консервации. Скадовск " +
            "расположен как раз над морским фарватером, в его устье есть " +
            "площадка с горным тоннелем метро.",
            "Такой вот примерно рецепт усредненный, потому что вариаций " +
            "масса. Берется суп, он не греется, а ставится на противень," +
            " сверху накрывается крышкой, сверху кладут катышек, потом" +
            " что-то такое, потом еще что-то, завернутое в фольгу." +
            " И так чередуется. В общем, как в наших парикмахерских.",
            "Представьте, вы стоите в бесконечно большой тёмной комнате " +
            "и излучаете свет по направлению взгляда, луч будет продолжаться" +
            " в том же направлении бесконечно, нет причин предполагать, что он" +
            " вернётся к вам в спину. Но червоточина меняет топологию пространства-времени," +
            " сгибает его. Ничто более не находится на своём месте. Когда луч прекращает" +
            " вращаться в вашей голове, вы чувствуете некоторую свободу от чёрных" +
            " энергетических воронок, они смотрят на вас с чистого голубого неба и" +
            " не заботятся, стоит ли за вами что— то. На самом деле, чёрные энергии" +
            " просто не видят вас, потому что вы всё равно их не видите.",
            "In the first age, in the first battle, when the shadows first " +
            "lengthened, one stood. he stood above the water. He was one of the kitchen.",
            "And blood-black nothingness began to spin... A system of cells interlinked " +
            "within cells interlinked within cells interlinked within one stem..." +
            "And dreadfully distinct against the dark, a tall white fountain played." +
            " Cells. Cells. Have you ever been in an institution? Cells. Cells." +
            " When you're not performing your duties do they keep you in a" +
            " little box? Cells. Cells.",
            "Have you heard of the Talos Principle? It's this old" +
            " philosophical concept about the impossibility of avoiding" +
            " reality - no matter what you believe, if you lose your blood," +
            " you will die. I think that applies to our situation more than" +
            " we'd like to admit. We could close our eyes and pretend that" +
            " everything's going to be all right... but it won't change the physical" +
            " reality of what's going to happen to our natures.  Nothing never never " +
            "might be put up into the gloom.  I can tell you out.  I never told you " +
            "anything in that way before. No should you doubt."
            };
        }
        
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

            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }

            for (int i = 0; i <= n; d[i, 0] = i++) { }
            for (int j = 0; j <= m; d[0, j] = j++) { }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (second_str[j - 1] == first_str[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
        public WordsOnReaction(Language lang, Difficulty difficulty) {
            if (textsForExercise == null)
                Init();
            Text = textsForExercise[(int)lang * 3 + (int)difficulty];
            Time = TimeSpan.FromSeconds(100.0);
        }

        public bool check(object statistic) {return false;}
    }
}
