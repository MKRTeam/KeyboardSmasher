using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.Gameplay
{
    struct EventAction
    {
        public string Description { get; }
        public ExerciseType execise_code { get; }

        public EventAction(string desctiprion, ExerciseType exercise_code);
    }

    class Event
    {
        private EventObject event_object;
        private EventAction[] actions;
        public string Description { get; }
        //сюда можно добавить картинку какую-то или звук

        public Event(string description, EventObject event_object, EventAction[] actions);

        public string[] getActions();

        public ExerciseType getActionResult(uint action_index);
    }
}
