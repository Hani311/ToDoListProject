using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ToDoList
    {
        private List<Task> tasks;
        string filePath = "C:\\VScode repos .net\\ToDoListProject\\ToDoListProject\\todolist.txt"; //create the file path  make sure to select your own path for your file


        public ToDoList(string filePath)
        {
            this.filePath = filePath;
            tasks = new List<Task>();
            LoadTasksFromFile();
        }

        private void LoadTasksFromFile()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');
                        Task task = new Task
                        {

                            ToDo = parts[0],
                            Description = parts[1],
                            DueDate = DateTime.Parse(parts[2]),
                            IsCompleted = bool.Parse(parts[3])
                        };
                        tasks.Add(task);
                    }
                }
            }
        }

        private void SaveTasksToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Task task in tasks)
                {
                    string line = $"{task.ToDo},{task.Description},{task.DueDate:yyyy-MM-dd},{task.IsCompleted}";
                    writer.WriteLine(line);
                }
            }
        }

        public void AddTask(string todo, string description, DateTime dueDate)
        {
            Task task = new Task
            {
                // Index = index,
                ToDo = todo,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false
            };
            tasks.Add(task);
            SaveTasksToFile();
        }

        public void EditTask(int index, string todo, string description, DateTime dueDate, bool isCompleted)
        {
            Task task = tasks[index - 1];
            task.ToDo = todo;
            task.Description = description;
            task.DueDate = dueDate;
            task.IsCompleted = isCompleted;
            SaveTasksToFile();
        }

        public void DeleteTask(string todo)
        {
            Task task = tasks.Find(t => t.ToDo == todo);
            tasks.Remove(task);
            SaveTasksToFile();
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }


    }
