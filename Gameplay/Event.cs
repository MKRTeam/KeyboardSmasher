using Gameplay.ExerciseMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public struct EventAction
    {
        public string Description { get; }
        public ExerciseType execise_code { get; }

        public EventAction(string desctiprion, ExerciseType exercise_code)
        {
            if (desctiprion == "" || desctiprion == null)
            {
                throw new Exception("Описание пустое, структура EventAction");
            }
            Description = desctiprion;
            this.execise_code = exercise_code;

        }

        public override string ToString()
        {
            return Description;
        }
    }

    public class Event
    {
        private EventObject event_object;
        private EventAction[] actions;
        public string Description { get; }
        //сюда можно добавить картинку какую-то или звук

        public Event(string description, EventObject event_object, EventAction[] actions)
        {
            Description = description;
            this.event_object = event_object;
            this.actions = actions;

        }

        public string[] getActions()
        {
            /*Получить список описаний*/
            string[] arr_name_action = new string[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                arr_name_action[i] = actions[i].Description;
            }
            return arr_name_action;
        }

        public ExerciseType getActionResult(uint action_index)
        {
            if(action_index>=actions.Length)
                throw new Exception("Выход за пределы массива, класс Event");
            return actions[action_index].execise_code;
        }
    }
}
