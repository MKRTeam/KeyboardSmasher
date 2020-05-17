using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.ExerciseMachine
{
    interface ExerciseMachine
    {
        bool start(out object statistic);
    }
}
