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
            "Лисицы являются довольно любопытными животными." + 
            "Главные их чувства - слух и обоняние. Не различают цветов, особенно днем, поэтому могут очень близко подойти к неподвижному человеку со стороны ветра." +
            "Способны услышать мелких грызунов под толщей снега." +
            "Являются хищниками, но могут питаться достаточно разнообразно." ,

            "Глухарь обыкновенный — представитель самой крупной лесной пернатой дичи." +
            "Он принадлежит к отряду курообразных, семейству фазановых, подсемейству тетеревиных, роду глухарей." +  
            "Обитает в хвойных, смешанных и лиственных лесах Евразии." +
            "Самцы имеют длину от 74 до 110 см в зависимости от подвида, размах крыльев от 90 до 1,4 м, " +
            "средний вес 4,1 кг — 6,7 кг. Самый большой образец, зарегистрированный в неволе, " +
            "имел вес 7,2 кг. Самка намного меньше, весит примерно вдвое меньше. Длина тела несушек от клюва до" +
            " хвоста составляет приблизительно 54–64 см, размах крыльев — 70 см, а вес 1,5–2,5 кг, в среднем 1,8 кг.",

            "Внешне росомаха напоминает медведя или барсука: " +
            "тело у неё приземистое, неуклюжее; ноги короткие, " +
            "задние длиннее передних, из-за чего спина росомахи дугообразно" +
            " изогнута кверху. Голова большая, морда удлинённая, затупленная" +
            " спереди; хвост недлинный, очень пушистый. Ее вес 11-19 кг, " +
            "а длина 70-90 см. Большую часть жизни росомаха проводит в " +
            "одиночестве, активно защищая границы своей территории от особей" +
            " своего пола. Большую часть жизни росомаха проводит в одиночестве," +
            " активно защищая границы своей территории от особей своего пола. " +
            "Росомаха всеядна. Росомаху побаиваются даже волки и медведи. " +
            "Она может охотится даже на зверей в 5 раз больше ее собственного" +
            " размера. Росомаха бегает небыстро, но очень вынослива и берёт " +
            "свою жертву измором. Однако несмотря на всю ее силу, росомаха " +
            "занесена в Международную Красную книгу.",

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
