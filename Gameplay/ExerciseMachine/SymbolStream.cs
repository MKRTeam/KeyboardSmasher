using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
{
    struct SymbolStreamStatistic
    {

    }

    class SymbolStream// : ExerciseMachine
    {
        //наборы символов для каждого уровня сложности
        private static Dictionary<Difficulty, char[]> symbol_sets = null;
        //размер очереди букв
        private const uint symbols_queue_size = 5;

        //кол-во букв в испытании. зависит от сложности
        public uint SymbolsCount { get; }

        //выбранный набор букв. зависит от сложности
        public char[] SymbolsSet { get; }

        //время на одну букву. зависит от сложности
        public TimeSpan TimePerSymbol { get; }

        public SymbolStream(Difficulty difficulty)
        {

            //если не выполнена инициализация symbol_sets то выкинуть исключение и не дать создать объект!!


            //здесь происходит определение того, какой набор букв будет в испытании, сколько символов будет
        }

        //сам словарь формируется где-нибудь в main и сюда передается
        //public static void Init(Dictionary<Difficulty, char[]> symbol_sets);


        //public override bool start(out object statistic);
    }
}
