using System;

namespace Manager.BL.Model
{
    public class Tasks
    {
        /// <summary>
        /// Имя задачи.
        /// </summary>
        public string TaskName { get; }

        /// <summary>
        /// Создать новую задачу.
        /// </summary>
        /// <param name="task"> Присвоить имя задаче. </param>
        public Tasks(string task)
        {
            // TODO: проверка

            TaskName = task;
        }
    }
}
