namespace TaskManager.Classes
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public Employee(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }

        public void WorkOnTask(Task task)
        {
            if (task.Implementor == Name)
            {
                task.StartWork(Name);
            }
            else
            {
                throw new InvalidOperationException("Сотрудник не назначен на эту задачу.");
            }
        }
    }

}
