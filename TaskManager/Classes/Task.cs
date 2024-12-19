using TaskStatus = TaskManager.Enums.TaskStatus;

namespace TaskManager.Classes
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Orderer { get; set; }
        public string Implementor { get; set; }
        public TaskStatus Status { get; set; }
        public Report Report { get; set; }

        public Task(string description, DateTime deadline, string orderer)
        {
            Description = description;
            Deadline = deadline;
            Orderer = orderer;
            Status = TaskStatus.Назначена;
        }

        public void StartWork(string assignee)
        {
            Implementor = assignee;
            Status = TaskStatus.ВРаботе;
        }
        public void DelegateTask(string newAssignee)
        {
            Implementor = newAssignee;
            Status = TaskStatus.Назначена;
        }
        public void RejectTask()
        {
            Implementor = null;
            Status = TaskStatus.Назначена;
        }
        public void CompleteTask(string reportText)
        {
            Report = new Report(reportText, DateTime.Now, Implementor);
            Status = TaskStatus.Выполнена;
        }
    }
}
