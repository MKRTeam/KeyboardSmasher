using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.ExerciseMachine
{
    struct WordsOnReactionStatistic
    {

    }

    class WordsOnReaction// : ExerciseMachine
    {
        //текст, который дадим писать пользователю
        public string Text { get; }

        //Время на все испытание
        public TimeSpan Time { get; }

        public WordsOnReaction(Difficulty difficulty)
        {

        }

        //public override bool start(out object statistic);
    }
}
