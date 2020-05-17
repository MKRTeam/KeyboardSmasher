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
        public MistakeCount()
        {

        }

        public override bool start(out object statistic);
    }
}
