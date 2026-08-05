public class TodoApp
{
    private readonly List<string> _tasks = new();
    private readonly Dictionary<string, List<int>> _tags =
        new(StringComparer.OrdinalIgnoreCase);

    public void Run()
    {
        Console.WriteLine("Simple To-Do Manager");
        Console.WriteLine(
            "Commands: add [item], show, remove [index], clear, " +
            "tag [index] [name], get-tagged [tag], exit"
        );

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

            try
            {
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

                    case "tag":
                        TagTask(argument);
                        break;

                    case "get-tagged":
                        ShowTaggedTasks(argument);
                        break;

                    case "exit":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine(
                            "Unknown command. Use add, show, remove, clear, " +
                            "tag, get-tagged, or exit."
                        );
                        break;
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (InvalidOperationException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (KeyNotFoundException error)
            {
                Console.WriteLine($"Error: {error.Message}");
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
        UpdateTagIndicesAfterRemoval(listIndex);

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
        _tags.Clear();

        Console.WriteLine("All tasks and tags have been cleared.");
    }

    private void TagTask(string argument)
    {
        string[] parts = argument.Split(
            ' ',
            2,
            StringSplitOptions.RemoveEmptyEntries
        );

        if (parts.Length < 2)
        {
            throw new ArgumentException(
                "Use: tag [index] [name]. Example: tag 1 urgent."
            );
        }

        if (!int.TryParse(parts[0], out int userIndex))
        {
            throw new ArgumentException(
                "Task index must be a number."
            );
        }

        if (userIndex < 1 || userIndex > _tasks.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(userIndex),
                $"Task index must be between 1 and {_tasks.Count}."
            );
        }

        string tagName = parts[1].Trim();

        if (string.IsNullOrWhiteSpace(tagName))
        {
            throw new ArgumentException(
                "Tag name cannot be empty."
            );
        }

        int listIndex = userIndex - 1;
        if (!_tags.TryGetValue(tagName, out List<int>? indices))
        {
            indices = new List<int>();
            _tags[tagName] = indices;
        }
        if (indices.Contains(listIndex))
        {
            throw new InvalidOperationException(
                $"Task {userIndex} already has the tag \"{tagName}\"."
            );
        }

        indices.Add(listIndex);

        Console.WriteLine(
            $"Tag \"{tagName}\" added to task {userIndex}: " +
            $"{_tasks[listIndex]}"
        );
    }

    private void ShowTaggedTasks(string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
        {
            throw new ArgumentException(
                "Use: get-tagged [tag]. Example: get-tagged urgent."
            );
        }

        if (!_tags.TryGetValue(tagName, out List<int>? indices))
        {
            throw new KeyNotFoundException(
                $"Tag \"{tagName}\" was not found."
            );
        }

        Console.WriteLine($"Tasks tagged \"{tagName}\":");

        foreach (int listIndex in indices)
        {
            Console.WriteLine(
                $"{listIndex + 1}. {_tasks[listIndex]}"
            );
        }
    }

    private void UpdateTagIndicesAfterRemoval(int removedIndex)
    {
        List<string> emptyTags = new();

        foreach (KeyValuePair<string, List<int>> tag in _tags)
        {
            List<int> indices = tag.Value;
            indices.Remove(removedIndex);
            for (int i = 0; i < indices.Count; i++)
            {
                if (indices[i] > removedIndex)
                {
                    indices[i]--;
                }
            }

            if (indices.Count == 0)
            {
                emptyTags.Add(tag.Key);
            }
        }
        foreach (string tagName in emptyTags)
        {
            _tags.Remove(tagName);
        }
    }
}