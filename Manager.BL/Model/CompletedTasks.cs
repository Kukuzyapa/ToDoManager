using System;

namespace Manager.BL.Model
{
    public class CompletedTasks
    {
        /// <summary>
        /// Имя выполненной задачи.
        /// </summary>
        public string TaskName { get; }

        /// <summary>
        /// Создать новую выполненную задачу.
        /// </summary>
        /// <param name="task"> Присвоить имя выполненной задаче. </param>
        public CompletedTasks(string task)
        {
            // TODO: Проверка

            TaskName = task;
        }
    }
}
