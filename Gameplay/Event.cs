using Gameplay.ExerciseMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public class EventAction
    {
        public string Description { get; set; }
        public ExerciseType ExerciseCode { get; set; }
       
        public EventAction(string desctiprion, ExerciseType exercise_code)
        {
            if (desctiprion == "" || desctiprion == null)
            {
                throw new Exception("Описание пустое, структура EventAction");
            }
            Description = desctiprion;
            this.ExerciseCode = exercise_code;

        }
        
        public override string ToString()
        {
            return Description;
        }
    }

    public class Event
    {
        public EventAction[] Actions { get; }
        public string Description { get; set; }
        //сюда можно добавить картинку какую-то или звук
        public string FileNameImage { get; set; }
        public string FileNameMusic { get; set; }
        public Event(string description, EventAction[] actions)
        {
            if (description == null || description == "")
            {
                throw new Exception("Не задано описание события, класс Event");
            }
            Description = description;
            this.Actions = actions;

        }
        public override string ToString()
        {
            return Description;
        }
        public string[] getActions()
        {
            /*Получить список описаний*/
            string[] arr_name_action = new string[Actions.Length];
            for (int i = 0; i < Actions.Length; i++)
            {
                arr_name_action[i] = Actions[i].Description;
            }
            return arr_name_action;
        }

        public ExerciseType getActionResult(uint action_index)
        {
            if(action_index>=Actions.Length)
                throw new Exception("Выход за пределы массива, класс Event");
            return Actions[action_index].ExerciseCode;
        }
    }
}
