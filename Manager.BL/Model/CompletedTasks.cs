using System;

namespace Manager.BL.Model
{
    [Serializable]
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
            TaskName = task;
        }

        public override string ToString()
        {
            return TaskName;
        }
    }
}
