using TaskManager.Enums;
using TaskStatus = TaskManager.Enums.TaskStatus;

namespace TaskManager.Classes
{
    public class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Orderer { get; set; }
        public string TeamLeader { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, string orderer, string teamLeader)
        {
            Description = description;
            Deadline = deadline;
            Orderer = orderer;
            TeamLeader = teamLeader;
            Tasks = new List<Task>();
            Status = ProjectStatus.Проект;
        }

        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                Tasks.Add(task);
            }
            else
            {
                throw new InvalidOperationException("Задачи можно добавлять только в статусе 'Проект'");
            }
        }
        public void StartExecution()
        {
            if (Status == ProjectStatus.Проект)
            {
                Status = ProjectStatus.Исполнение;
            }
            else
            {
                throw new InvalidOperationException("Проект может быть переведен в статус 'Исполнение' только из статуса 'Проект'.");
            }
        }
        public bool IsClosed()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
