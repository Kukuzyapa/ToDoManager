﻿using Manager.BL.Model;
using System;
using System.Collections.Generic;

namespace Manager.BL.Control
{
    public class CompletedController
    {
        /// <summary>
        /// Получить выполненную задачу
        /// </summary>
        public CompletedTasks Completed { get; private set; }

        public List<CompletedTasks> CompletedTaskList = new List<CompletedTasks>();

        /// <summary>
        /// Создать новый контроллер выполненной задачи
        /// </summary>
        /// <param name="task"> Выполненная задача. </param>
        public CompletedController(TasksController task)
        {
            // TODO: Проверка

            Completed = new CompletedTasks(task.Tasks.TaskName);
            CompletedTaskList.Add(Completed);
        }

        public CompletedController()
        {

        }

        public void GetCompletedTasks()
        {
            int i = 1;

            foreach (CompletedTasks t in CompletedTaskList)
            {
                Console.WriteLine("\t" + i++ + ") " + t);
            }
        }


        public override string ToString()
        {
            return Completed.TaskName;
        }
    }
}
