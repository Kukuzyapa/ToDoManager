using Manager.BL.Control;
using Manager.BL.Model;
using System;
using System.Collections.Generic;

namespace Manager.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var Tasks = new List<TasksController>();
            var Completed = new List<CompletedController>();

            Console.WriteLine("Вас приветсвует приложение ToDoManager");

            while (true)
            {
                int i = 1;
                int Key;

                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести задачи\nL - посмотреть задачи\nC - посмотреть выполненные задачи");

                var ChoiceKey = Console.ReadKey();
                Console.WriteLine();

                switch (ChoiceKey.Key)
                {
                    case ConsoleKey.E:

                        Console.Clear();

                        Console.WriteLine("Введите задачу");
                        Tasks.Add(new TasksController(Console.ReadLine()));
                        Console.Clear();

                        break;

                    case ConsoleKey.L:

                        Console.Clear();

                        foreach(TasksController t in Tasks)
                        {
                            Console.WriteLine("\t" + i++ + ") " + t);
                        }

                 
                        Console.WriteLine("D - удалить задачу\nC - выполнить задачу\nAnyKey - вернуться назад");
                        var Choice = Console.ReadKey();
                        Console.WriteLine();
                        switch (Choice.Key)
                        {
                            case ConsoleKey.D:

                                Console.WriteLine("Какую задачу вы хотите удалить?");
                                Key = Convert.ToInt32(Console.ReadLine());
                                Tasks.RemoveAt(Key - 1); // TODO: Переписать

                                Console.Clear();

                                break;

                            case ConsoleKey.C:

                                Console.WriteLine("Какую задачу вы хотите выполнить?");
                                Key = Convert.ToInt32(Console.ReadLine());
                                Completed.Add(new CompletedController(Tasks[Key - 1])); // TODO: Переписать

                                Console.Clear();

                                break;

                            default:

                                Console.Clear();

                                break;
                        }
                        
                        break;

                    case ConsoleKey.C:

                        Console.Clear();

                        foreach (CompletedController t in Completed)
                        {
                            Console.WriteLine("\t" + i++ + ") " + t);
                        }

                        break;
                }
            }
        }
    }
}
