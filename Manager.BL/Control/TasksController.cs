using System;
using Manager.BL.Model;

namespace Manager.BL.Control
{
    public class TasksController
    {
        /// <summary>
        /// Получить задачу.
        /// </summary>
        public Tasks Tasks { get; }

        /// <summary>
        /// Создать новый контрлллер задачи.
        /// </summary>
        /// <param name="task"> Задача </param>
        public TasksController(string task)
        {
            // TODO: Проверка

            Tasks = new Tasks(task);
        }


        public override string ToString()
        {
            return Tasks.TaskName;
        }
    }
}
