using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, bool> tasks = new Dictionary<string, bool>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the task manager!");

        while (true)
        {
            Console.Write("Enter a command (add-item, remove-item, mark-as, show, exit): ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "add-item":
                    AddItem();
                    break;
                case "remove-item":
                    RemoveItem();
                    break;
                case "mark-as":
                    MarkAs();
                    break;
                case "show":
                    Show();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }

    static void AddItem()
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine().ToLower();

        if (!tasks.ContainsKey(task))
        {
            tasks.Add(task, false);
            Console.WriteLine("Task added successfully.");
        }
        else
        {
            Console.WriteLine("Task already exists.");
        }
    }

    static void RemoveItem()
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine().ToLower();

        if (task == "*")
        {
            tasks.Clear();
            Console.WriteLine("All tasks removed.");
        }
        else if (tasks.ContainsKey(task))
        {
            tasks.Remove(task);
            Console.WriteLine("Task removed successfully.");
        }
    }

    static void MarkAs()
    {
        Console.Write("Enter status (1 - done, 0 - not done): ");
        if (!int.TryParse(Console.ReadLine(), out int status))
        {
            Console.WriteLine("Invalid status.");
            return;
        }

        Console.Write("Enter task: ");
        string task = Console.ReadLine().ToLower();

        if (tasks.ContainsKey(task))
        {
            tasks[task] = status == 1;
            if (status == 1)
            {
                Console.Write("Enter date (leave empty for current date): ");
                string dateInput = Console.ReadLine();
                DateTime date = string.IsNullOrEmpty(dateInput) ? DateTime.Now : DateTime.Parse(dateInput);
                tasks[task] = true;
                Console.WriteLine($"Task marked as done on {date.ToShortDateString()}");
            }
            else
            {
                tasks[task] = false;
                Console.WriteLine("Task marked as not done.");
            }
        }
    }

    static void Show()
    {
        Console.Write("Enter status (1 - done, 0 - not done): ");
        if (!int.TryParse(Console.ReadLine(), out int status))
        {
            Console.WriteLine("Invalid status.");
            return;
        }

        foreach (var kvp in tasks)
        {
            if ((status == 1 && kvp.Value) || (status == 0 && !kvp.Value))
            {
                Console.WriteLine($"Task: {kvp.Key} (Done: {kvp.Value})");
            }
        }
    }
}
