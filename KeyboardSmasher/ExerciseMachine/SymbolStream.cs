using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.ExerciseMachine
{
    struct SymbolStreamStatistic
    {

    }

    class SymbolStream : ExerciseMachine
    {
        private static Dictionary<Difficulty, char[]> symbol_sets = null;


        private uint general_symbols_count;//это зависит от сложности
        private const uint symbols_queue_size = 5;//можно изменить

        public SymbolStream(Difficulty level)
        {
            //если не выполнена инициализация symbol_sets то выкинуть исключение и не дать создать объект!!
        }

        //сам словарь формируется где-нибудь в main и сюда передается
        public static void Init(Dictionary<Difficulty, char[]> symbol_sets);


        public override bool start(out object statistic);
    }
}
