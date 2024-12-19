using TaskManager.Classes;
using TaskManager.Enums;
using Task = TaskManager.Classes.Task;

class Program
{
    static void Main()
    {
        Task1();
    }
    public static void Task1()
    {
        Project project = new Project("Разработка кроссплатформы для приложения", DateTime.Now.AddMonths(3), "Клиент", "Тимлид");

        TeamLeader teamLeader = new TeamLeader("Тимлид");

        List<Employee> employees = new List<Employee>();
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(new Employee($"Сотрудник {i}"));
        }


        for (int i = 1; i <= 10; i++)
        {
            Task task = new Task($"Задача {i}", DateTime.Now.AddDays(30), "Клиент");
            project.AddTask(task);
            teamLeader.AssignTask(task, employees[i % 10]);
        }

        project.StartExecution();

        foreach (var task in project.Tasks)
        {
            if (task.Implementor != null)
            {
                var employee = employees.Find(e => e.Name == task.Implementor);
                employee.WorkOnTask(task);
                task.CompleteTask("Задача выполнена успешно");
                teamLeader.ReviewReport(task);
            }
        }
        if (project.IsClosed())
        {
            project.Status = ProjectStatus.Закрыт;
            Console.WriteLine("Проект закрыт.");
        }
        else
        {
            Console.WriteLine("Проект все еще в работе.");
        }
        ShowProjectDetails(project);
        ShowEmployeeTasks(employees);


    }
    static void ShowProjectDetails(Project project)
    {
        Console.WriteLine($"Проект: {project.Description}");
        Console.WriteLine($"Срок выполнения: {project.Deadline}");
        Console.WriteLine($"Статус: {project.Status}");
        Console.WriteLine("Задачи:");
        foreach (var task in project.Tasks)
        {
            Console.WriteLine($" - {task.Description}: {task.Status} (Исполнитель: {task.Implementor})");
        }
    }

    static void ShowEmployeeTasks(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Задачи для {employee.Name}:");
            foreach (var task in employee.Tasks)
            {
                Console.WriteLine($" - {task.Description}: {task.Status}");
            }
        }
    }
}