using System;

namespace Manager.BL.Model
{
    [Serializable]
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
            TaskName = task;
        }

        public override string ToString()
        {
            return TaskName;
        }
    }
}
