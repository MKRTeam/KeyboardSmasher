using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
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

        public bool check(object statistic)
        {
            return false;
        }
    }
}
