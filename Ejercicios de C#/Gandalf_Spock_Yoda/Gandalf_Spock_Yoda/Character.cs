using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gandalf_Spock_Yoda
{
    class Character
    {
        private String name;
        private int scoreboard;
        private InterfaceTask.TaskType imposibleTask;
        private Queue<Task> taskQueue = new Queue<Task>();
        private Stack<Task> noPosibleTasks = new Stack<Task>();

        public Character(String name, InterfaceTask.TaskType imposibleTask)
        {
            this.name = name;
            this.scoreboard = 0;
            this.imposibleTask = imposibleTask;
            
        }

        public int Scoreboard { get => scoreboard; set => scoreboard = value; }
        public InterfaceTask.TaskType ImposibleTask { get => imposibleTask; set => imposibleTask = value; }
        public Queue<Task> TaskQueue { get => taskQueue; set => taskQueue = value; }
        public Stack<Task> NoPosibleTasks { get => noPosibleTasks; set => noPosibleTasks = value; }
        public string Name { get => name; set => name = value; }

        public void addPoints(int taskScore) // adds the score of the task to the scoreboard
        {
            this.scoreboard = scoreboard + taskScore;
        }

        

    }
}
