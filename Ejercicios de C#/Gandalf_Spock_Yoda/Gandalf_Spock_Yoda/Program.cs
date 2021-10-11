using System;
using System.Threading;

namespace Gandalf_Spock_Yoda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the characters
            Character Spock = new Character("Spock", InterfaceTask.TaskType.force);
            Character Gandalf = new Character("Gandalf", InterfaceTask.TaskType.logical);
            Character Yoda = new Character("Yoda", InterfaceTask.TaskType.magical);

            Character[] characters = new Character[3];
            characters[0] = Spock;
            characters[1] = Gandalf;
            characters[2] = Yoda;

            int max_time = 5*60; // 5 minutes
            int time = 1;

            do
            {
                if (time % 1 == 0)
                {
                    Console.WriteLine("Every second");

                    // Asign the tasks
                    Task newTask = new Task();
                    assignTask(characters, newTask);
                    

                }

                if (time % 2 == 0)
                {
                    Console.WriteLine("Every 2 seconds");

                    //Do the tasks
                    foreach (Character c in characters)
                    {
                        if (c.TaskQueue.Count > 0)
                        {
                            Task nextTask = c.TaskQueue.Dequeue();

                            if (canDoTask(c, nextTask))
                            {
                                c.addPoints(nextTask.Score);
                                Console.WriteLine(c.Name + " +"+ nextTask.Score +" point ");
                            }
                            else
                            {
                                c.NoPosibleTasks.Push(nextTask);
                                Console.WriteLine(c.Name + " can't do the task ");
                            }
                        }
                        

                    }

                    Console.WriteLine("----------------------------------");

                }

                Thread.Sleep(1000);
                time += 1;

            } while (time <= max_time);

            //Show the winner

            showWinner(characters);



        }

        static void assignTask(Character[] characters, Task newTask) // assing the task to the proper character
        {
            if ((newTask.Code % 2) == 0)
            {
                characters[0].TaskQueue.Enqueue(newTask);
                Console.WriteLine("Task assigned to " + characters[0].Name);
            }
                    
            if ((newTask.Code % 3) == 0)
            {
                characters[1].TaskQueue.Enqueue(newTask);
                Console.WriteLine("Task assigned to " + characters[1].Name);
            }
                   
            if ((newTask.Code % 5) == 0)
            {
                characters[2].TaskQueue.Enqueue(newTask);
                Console.WriteLine("Task assigned to " + characters[2].Name);
            }
        }

        static Boolean canDoTask(Character c, Task newTask) // return boolean if the character can perform the task
        {
            Boolean candoit = true;

            if (newTask.TaskType.Equals(c.ImposibleTask))
            {
                candoit = false;
            }   

            return candoit;
        }

        static void showWinner(Character[] characters) // finds the winner in the characters array and show it as well as his scoreboard
        {
            Character winner = null;
            int maxScoreboard = 0;

            foreach (Character c in characters)
            {
                if (maxScoreboard < c.Scoreboard)
                {
                    maxScoreboard = c.Scoreboard;
                    winner = c;
                }
            }

            Console.WriteLine(winner.Name + " has won with " + winner.Scoreboard + " points.");
        }
    }
}
