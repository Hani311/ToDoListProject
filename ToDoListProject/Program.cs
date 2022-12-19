using System.Threading.Tasks;

ToDoList toDoList = new ToDoList("C:\\VScode repos .net\\ToDoListProject\\ToDoListProject\\todolist.txt"); // select your own path for your file

 bool isCompleted;
 while (true)
{
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Edit Task");
    Console.WriteLine("3. Delete Task");
    Console.WriteLine("4. View Tasks");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        List<Task> tasks = toDoList.GetTasks();
        Console.Write("Enter task name: ");
        string todo = Console.ReadLine();
        Console.Write("Enter a small task description: ");
        string description = Console.ReadLine();
        Console.Write("Enter due date: ");
        DateTime dueDate;
        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                 "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "yy/M/dd","yyyy/M/dd", "yyyy/MM/dd", "yy/MM/dd"};  // allow the user to write the date in different formats

        while (!DateTime.TryParseExact(Console.ReadLine(), formats,
             System.Globalization.CultureInfo.InvariantCulture,
             System.Globalization.DateTimeStyles.None,
             out dueDate))
        {
            Console.WriteLine("Your input is incorrect. Please input again.");
        }

        while (dueDate < DateTime.Now) // if the date is in the past will print a message and will ask to write the date again
        {
            Console.WriteLine("The date is in the past please write the date again", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            while (!DateTime.TryParseExact(Console.ReadLine(), formats,
             System.Globalization.CultureInfo.InvariantCulture,
             System.Globalization.DateTimeStyles.None,
             out dueDate))
            {
                Console.WriteLine("Your input is incorrect. Please input again.", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }
        }
        toDoList.AddTask(todo, description, dueDate);
    }
    else if (choice == 2)
    {
        List<Task> tasks = toDoList.GetTasks();
        Console.WriteLine("your list of tasks");
        int indexx = 0;
      

        Console.WriteLine("index".PadRight(15) + "ToDo".PadRight(30) + "Description".PadRight(50) + "DueDate".PadRight(15) + "Status".PadRight(15));
        foreach (Task task in tasks)
        {
            indexx = indexx + 1;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(indexx.ToString().PadRight(15) + task.ToDo.PadRight(30) + task.Description.PadRight(50) + task.DueDate.ToString("yyyy-MM-dd").PadRight(15) + task.IsCompleted.ToString().PadRight(15));
            Console.ResetColor();
        }
        Console.WriteLine("------------------------------------------------------------------");

        Console.Write("Enter the \u001b[31mTASK NUMBER\u001b[0m to edit ");
        int index = int.Parse(Console.ReadLine());
        // if the indexx not in the list show error
        while (index > tasks.Count)
        {
            Console.WriteLine("The task number is not in the list", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.Write("Enter the \u001b[31mTASK NUMBER\u001b[0m to edit ");
            index = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter task name: ");
        string todo = Console.ReadLine();
        Console.WriteLine("Enter task description: ");
        string description = Console.ReadLine();
        Console.Write("Enter due date: ");
        DateTime dueDate;
        string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                 "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "yy/M/dd","yyyy/M/dd", "yyyy/MM/dd", "yy/MM/dd"};  // allow the user to write the date in different formats

        while (!DateTime.TryParseExact(Console.ReadLine(), formats,
             System.Globalization.CultureInfo.InvariantCulture,
             System.Globalization.DateTimeStyles.None,
             out dueDate))
        {
            Console.WriteLine("Your input is incorrect. Please input again.");
        }

        while (dueDate < DateTime.Now) // if the date is in the past will print a message and will ask to write the date again
        {
            Console.WriteLine("The date is in the past please write the date again", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            while (!DateTime.TryParseExact(Console.ReadLine(), formats,
             System.Globalization.CultureInfo.InvariantCulture,
             System.Globalization.DateTimeStyles.None,
             out dueDate))
            {
                Console.WriteLine("Your input is incorrect. Please input again.", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();

            }
        }
        Console.Write("Is completed? (true/false): ");
        isCompleted = bool.Parse(Console.ReadLine());
        toDoList.EditTask(index, todo, description, dueDate, isCompleted);
    }
    else if (choice == 3)
    {
        List<Task> tasks = toDoList.GetTasks();
        Console.WriteLine("ToDo".PadRight(30) + "Description".PadRight(50) + "DueDate".PadRight(15) + "Status".PadRight(15));
        foreach (Task task in tasks)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(task.ToDo.PadRight(30) + task.Description.PadRight(50) + task.DueDate.ToString("yyyy-MM-dd").PadRight(15) + task.IsCompleted.ToString().PadRight(15));
            Console.ResetColor();

        }
        Console.WriteLine("------------------------------------------------------------------");
        
        Console.Write("Enter \u001b[31mTASK NAME\u001b[0m to delete it form your list: ");
        string todo = Console.ReadLine();
        while (!tasks.Any(x => x.ToDo == todo))
        {
            Console.WriteLine("The task name is not in the list", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.Write("Enter \u001b[31mTASK NAME\u001b[0m to delete it form your list: ");
            todo = Console.ReadLine();
        }

        toDoList.DeleteTask(todo);
    }
    else if (choice == 4)
    {
        List<Task> tasks = toDoList.GetTasks();
        List<Task> sorted = tasks.OrderBy(o => o.DueDate).ToList();
        Console.WriteLine("your list of tasks");
        Console.WriteLine("ToDo".PadRight(30) + "Description".PadRight(50) + "DueDate".PadRight(15) + "Status".PadRight(15));
        foreach (Task task in sorted)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(task.ToDo.PadRight(30) + task.Description.PadRight(50) + task.DueDate.ToString("yyyy-MM-dd").PadRight(15) + task.IsCompleted.ToString().PadRight(15));
            Console.ResetColor();

        }
        Console.WriteLine("------------------------------------------------------------------");

    }
    else if (choice == 5)
    {
        break;
    }
}
 