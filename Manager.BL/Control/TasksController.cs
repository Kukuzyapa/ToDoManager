using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Manager.BL.Model;

namespace Manager.BL.Control
{
    [Serializable]
    public class TasksController
    {
        /// <summary>
        /// Задачи.
        /// </summary>
        public Tasks Tasks { get; private set; }

        /// <summary>
        /// Выполненные задачи.
        /// </summary>
        public CompletedTasks CompletedTasks { get; private set; }

        /// <summary>
        /// Список выполненных задач.
        /// </summary>
        public List<CompletedTasks> CompletedTasksList { get; }

        /// <summary>
        /// Список задач.
        /// </summary>
        public List<Tasks> TaskList { get; }

        /// <summary>
        /// Создать новый контроллер задач.
        /// </summary>
        public TasksController()
        {
            CompletedTasksList = new List<CompletedTasks>();
            TaskList = new List<Tasks>();
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="task"> Имя задачи. </param>
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

        /// <summary>
        /// Добавить выполненную задачу
        /// </summary>
        /// <param name="key"> Номер задачи. </param>
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

        /// <summary>
        /// Выполнить все задачи.
        /// </summary>
        public void CompleteAllTasks()
        {
            foreach (Tasks t in TaskList)
            {
                CompletedTasks = new CompletedTasks(t.TaskName);
                CompletedTasksList.Add(CompletedTasks);
            }

            ClearTasks();            
        }

        /// <summary>
        /// Удалить задачу.
        /// </summary>
        /// <param name="key"> Номер задачи. </param>
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

        /// <summary>
        /// Удалить выполненную задачу.
        /// </summary>
        /// <param name="key"> Номер задачи. </param>
        public void DeleteCompletedTask(int key)
        {
            if (key > CompletedTasksList.Count || key <= 0)
            {
                Console.Clear();

                Console.WriteLine("Нет задачи с таким номером.\nAnyKey - вернуться назад.");
                Console.ReadKey();
            }
            else
            {

                CompletedTasksList.RemoveAt(key - 1);
            }
        }

        /// <summary>
        /// Получить задачи.
        /// </summary>
        public void GetTasks()
        {
            int number = 1;

            foreach (Tasks t in TaskList)
            {
                Console.WriteLine("\t" + number++ + ") " + t);
            }
        }

        /// <summary>
        /// Получить выполненные задачи.
        /// </summary>
        public void GetCompletedTasks()
        {
            int number = 1;

            foreach (CompletedTasks t in CompletedTasksList)
            {
                Console.WriteLine("\t" + number++ + ") " + t);
            }
        }

        /// <summary>
        /// Очистить список задач.
        /// </summary>
        public void ClearTasks()
        {
            TaskList.Clear();
        }

        /// <summary>
        /// Очистить список выполненных задач.
        /// </summary>
        public void ClearCompletedTasks()
        {
            CompletedTasksList.Clear();
        }

        /// <summary>
        /// Вернуть выполненную задачу в список активных задач.
        /// </summary>
        /// <param name="key"> Номер задачи. </param>
        public void ReturnTask(int key)
        {
            if (key > CompletedTasksList.Count || key <= 0)
            {
                Console.Clear();

                Console.WriteLine("Нет задачи с таким номером.\nAnyKey - вернуться назад.");
                Console.ReadKey();
            }
            else
            {
                Tasks = new Tasks(CompletedTasksList[key - 1].TaskName);
                TaskList.Add(Tasks);

                DeleteCompletedTask(key);
            }
        }

        /// <summary>
        /// Вернуть все выполненные задачи в список активных задач.
        /// </summary>
        public void ReturnAllTasks()
        {
            foreach(CompletedTasks t in CompletedTasksList)
            {
                Tasks = new Tasks(t.TaskName);
                TaskList.Add(Tasks);
            }

            ClearCompletedTasks();
        }

        /// <summary>
        /// Загрузить или создать контроллер задач.
        /// </summary>
        /// <returns></returns>
        public static TasksController Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Tasks.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is TasksController items)
                {
                    return items;
                }
                else
                {
                    return new TasksController();
                }
            }
        }

        /// <summary>
        /// Сохранить контроллер задач.
        /// </summary>
        /// <param name="item"> Контроллер. </param>
        public void Save(object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("Tasks.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
