namespace TaskManager.Classes
{
    public class TeamLeader
    {
        public string Name { get; set; }
        public List<Task> AssignedTasks { get; set; }
        public TeamLeader(string name)
        {
            Name = name;
            AssignedTasks = new List<Task>();
        }

        public void AssignTask(Task task, Employee employee)
        {
            task.Implementor = employee.Name;
            AssignedTasks.Add(task);
            employee.Tasks.Add(task);
        }

        public void ReviewReport(Task task)
        {
            if (task.Report != null)
            {
                Console.WriteLine($"Отчет по задаче '{task.Description}' проверен.");
            }
        }
    }
}
