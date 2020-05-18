using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
{
    //типа тренажеров
    public enum ExerciseType
    {
        NO_EXERCISE,
        SYMBOL_STREAM,
        WORDS_ON_REACTION,
        MISTAKE_COUNT
    }


    interface ExerciseMachine
    {
        bool start(out object statistic);
    }
}
