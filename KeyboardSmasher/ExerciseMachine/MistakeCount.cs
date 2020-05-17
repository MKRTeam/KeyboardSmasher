using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.ExerciseMachine
{
    struct MistakeCountStatistic
    {

    }

    class MistakeCount : ExerciseMachine
    {
        //текст который дадим писать пользователю
        public string Text { get; }//зависит от сложности
        
        public MistakeCount(Difficulty difficulty)
        {

        }

        public override bool start(out object statistic);
    }
}
