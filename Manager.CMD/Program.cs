using Manager.BL.Control;
using System;
using System.Collections.Generic;

namespace Manager.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Tasks = TasksController.Load();


            Console.WriteLine("Вас приветствует приложение ToDoManager");

            while (true)
            {
                int Key;

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести задачи\nL - посмотреть задачи\nC - посмотреть выполненные задачи\nQ - выйти");

                var ChoiceKey = Console.ReadKey();
                Console.WriteLine();

                switch (ChoiceKey.Key)
                {
                    case ConsoleKey.E: // Ввод задачи.

                        Console.Clear();

                        Console.WriteLine("Введите задачу");
                        
                        Tasks.AddTasks(Console.ReadLine());
                        Tasks.Save(Tasks);

                        Console.Clear();

                        break;

                    case ConsoleKey.L: // Просмотр задачи.

                        Console.Clear();
                       
                        if(Tasks.TaskList.Count == 0)
                        {
                            Console.WriteLine("Нет активных задач.\nAnyKey - Вернуться назад.");
                            Console.ReadKey();

                            Console.Clear();

                            break;
                        }
                        Tasks.GetTasks();
                        
                 
                        Console.WriteLine("D - удалить задачу\nC - выполнить задачу\nAnyKey - вернуться назад");

                        var Choice = Console.ReadKey();
                        Console.WriteLine();

                        switch (Choice.Key)
                        {
                            case ConsoleKey.D: // Удаление задачи.

                                Console.WriteLine("Какую задачу вы хотите удалить?");

                                if (Int32.TryParse(Console.ReadLine(), out Key)) 
                                {
                                    Tasks.DeleteTask(Key);

                                    Tasks.Save(Tasks);
                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("Некорректный номер задачи.\nAnyKey - вернуться назад.");
                                    Console.ReadKey();
                                }

                                Console.Clear();

                                break;

                            case ConsoleKey.C: // Выполнение задачи.

                                Console.WriteLine("Какую задачу вы хотите выполнить?");

                                if (Int32.TryParse(Console.ReadLine(), out Key))
                                {
                                    Tasks.AddCompletedTasks(Key);

                                    Tasks.Save(Tasks);
                                }
                                else
                                {
                                    Console.Clear();

                                    Console.WriteLine("Некорректный номер задачи.\nAnyKey - вернуться назад.");
                                    Console.ReadKey();
                                }

                                Console.Clear();

                                break;

                            default:

                                Console.Clear();

                                break;
                        }
                        
                        break;

                    case ConsoleKey.C: // Просмотр выполненных задач.

                        Console.Clear();

                        if (Tasks.CompletedTasksList.Count == 0)
                        {
                            Console.WriteLine("Нет выполненных задач.\nAnyKey - Вернуться назад.");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        }

                        Tasks.GetCompletedTasks();

                        break;

                    case ConsoleKey.Q:

                        Environment.Exit(0);

                        break;

                    default:

                        Console.Clear();

                        break;
                }
            }
        }
    }
}