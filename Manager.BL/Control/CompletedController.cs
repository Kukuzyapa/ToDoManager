using Manager.BL.Model;
using System;

namespace Manager.BL.Control
{
    public class CompletedController
    {
        /// <summary>
        /// Получить выполненную задачу
        /// </summary>
        public CompletedTasks Completed { get; }

        /// <summary>
        /// Создать новый контроллер выполненной задачи
        /// </summary>
        /// <param name="task"> Выполненная задача. </param>
        public CompletedController(TasksController task)
        {
            // TODO: Проверка

            Completed = new CompletedTasks(task.Tasks.TaskName);
        }


        public override string ToString()
        {
            return Completed.TaskName;
        }
    }
}
