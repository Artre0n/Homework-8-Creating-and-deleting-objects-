namespace TaskManager.Classes
{
    public class Report
    {
        public string Text { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Implementor { get; set; }

        public Report(string text, DateTime completionDate, string implementor)
        {
            Text = text;
            CompletionDate = completionDate;
            Implementor = implementor;
        }
    }
}
