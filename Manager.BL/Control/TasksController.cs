using System;
using System.Collections.Generic;
using Manager.BL.Model;

namespace Manager.BL.Control
{
    public class TasksController
    {
        /// <summary>
        /// Получить задачу.
        /// </summary>
        public Tasks Tasks { get; private set; }

        public CompletedTasks CompletedTasks { get; private set; }


        public List<CompletedTasks> CompletedTasksList = new List<CompletedTasks>();

        public List<Tasks> TaskList = new List<Tasks>();



        /// <summary>
        /// Создать новый контроллер задачи.
        /// </summary>
        /// <param name="task"> Задача </param>
        public TasksController(string task)
        {
            // TODO: Проверка

            Tasks = new Tasks(task);
            TaskList.Add(Tasks);
        }
        public TasksController()
        {
 
        }



        public void DeleteTask(int key)
        {
            if (key > TaskList.Count || key <= 0)
            {
                Console.Clear();
                Console.WriteLine("Нет задачи с таким номером.\nAnyKey - вернуться назад.");
                Console.ReadKey();
            }
            else
            {

                TaskList.RemoveAt(key - 1);
            }
        }

        public void GetTasks()
        {
            int i = 1;

            foreach (Tasks t in TaskList)
            {
                Console.WriteLine("\t" + i++ + ") " + t);
            }
        }
        public void GetCompletedTasks()
        {
            int i = 1;

            foreach (CompletedTasks t in CompletedTasksList)
            {
                Console.WriteLine("\t" + i++ + ") " + t);
            }
        }

        public void AddTasks(string task)
        {
            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("Задача не может быть пустой.\nAnyKey - вернуться назад.");
                Console.ReadKey();
            }
            else
            {
                Tasks = new Tasks(task);
                TaskList.Add(Tasks);
            }
        }

        public void AddCompletedTasks(int key)
        {
            if (key > TaskList.Count || key <= 0)
            {
                Console.Clear();
                Console.WriteLine("Нет задачи с таким номером.\nAnyKey - вернуться назад.");
                Console.ReadKey();
            }
            else
            {
                CompletedTasks = new CompletedTasks(TaskList[key - 1].TaskName);
                CompletedTasksList.Add(CompletedTasks);
                DeleteTask(key);
            }
        }





        public override string ToString()
        {
            return Tasks.TaskName;
        }
    }
}
