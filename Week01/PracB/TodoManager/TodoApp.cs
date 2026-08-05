public class TodoApp
{
    private readonly List<string> _tasks = new();

    public void Run()
    {
        Console.WriteLine("Simple To-Do Manager");
        Console.WriteLine("Commands: add [item], show, remove [index], clear, exit");

        while (true)
        {
            Console.Write("\n> ");

            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a command.");
                continue;
            }

            string[] parts = input.Split(
                ' ',
                2,
                StringSplitOptions.RemoveEmptyEntries
            );

            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1].Trim() : "";

            switch (command)
            {
                case "add":
                    AddTask(argument);
                    break;

                case "show":
                    ShowTasks();
                    break;

                case "remove":
                    RemoveTask(argument);
                    break;

                case "clear":
                    ClearTasks();
                    break;

                case "exit":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine(
                        "Unknown command. Use add, show, remove, clear, or exit."
                    );
                    break;
            }
        }
    }

    private void AddTask(string task)
    {
        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Task cannot be empty. Example: add Buy milk");
            return;
        }

        _tasks.Add(task);
        Console.WriteLine($"Task added: {task}");
    }

    private void ShowTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("The to-do list is empty.");
            return;
        }

        Console.WriteLine("To-do list:");

        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_tasks[i]}");
        }
    }

    private void RemoveTask(string indexText)
    {
        if (!int.TryParse(indexText, out int userIndex))
        {
            Console.WriteLine("Invalid index. Please enter a number.");
            return;
        }

        if (userIndex < 1 || userIndex > _tasks.Count)
        {
            Console.WriteLine("Task index is out of range.");
            return;
        }

        int listIndex = userIndex - 1;
        string removedTask = _tasks[listIndex];

        _tasks.RemoveAt(listIndex);

        Console.WriteLine($"Task removed: {removedTask}");
    }

    private void ClearTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("The to-do list is already empty.");
            return;
        }

        _tasks.Clear();
        Console.WriteLine("All tasks have been cleared.");
    }
}