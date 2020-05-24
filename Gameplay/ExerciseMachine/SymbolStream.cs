using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
{
    /// <summary>
    /// Структура для хранения статистики задания SymbolStream
    /// </summary>
    public struct SymbolStreamStatistic
    {
        /// <summary>
        /// Количество промахов (пропущенная буква или буква, нажатая преждевременно)
        /// </summary>
        public int missedCount;
        /// <summary>
        /// Количество верно нажатых букв
        /// </summary>
        public int correctCount;
    }

    public class SymbolStream : ExerciseMachine
    {
        //наборы символов для каждого уровня сложности
        private static Dictionary<Language, Dictionary<Difficulty, char[]>> symbol_sets_for_langs = null;
        private static Random rand = new Random();
        //кол-во букв в испытании. зависит от сложности
        public uint SymbolsCount { get; }

        //выбранный набор букв. зависит от сложности
        private char[] SymbolSet { get; }

        //время на одну букву. зависит от сложности
        public int SymbolSpeed { get; }

        public int TimeForSymbolCreation { get; }

        public SymbolStream(Language lang, Difficulty difficulty)
        {
            //если не выполнена инициализация symbol_sets то выкинуть исключение и не дать создать объект!!
            if (symbol_sets_for_langs == null)
                throw new Exception("Нет наборов символов");
            //здесь происходит определение того, какой набор букв будет в испытании, сколько символов будет
            SymbolSet = SymbolStream.symbol_sets_for_langs[lang][difficulty];
            SymbolsCount = 13u * ((uint)difficulty + 1u);
            SymbolSpeed = 1 * (Difficulty.HARD - difficulty + 1);
            TimeForSymbolCreation = 7 * ((int)difficulty + 1) / 6;
        }

        //сам словарь формируется где-нибудь в main и сюда передается
        public static void Init(Dictionary<Language, Dictionary<Difficulty, char[]>> symbol_sets_for_langs)
        {
            SymbolStream.symbol_sets_for_langs = symbol_sets_for_langs;
        }


        public bool check(object statistic)
        {
            return false;
        }

        public char getRandomSymbol()
        {
            int index = rand.Next(0, SymbolSet.Length);
            return this.SymbolSet[index];
        }
    }
}
