namespace SELApp.Models.Schedule
{
    public record DaySchedule
    {
        public DateOnly Date { get; }

        public IEnumerable<Class> Classes { get; }

        public DaySchedule(DateOnly date, IEnumerable<Class> classes)
        {
            Date = date;
            Classes = classes;
        }
    }
}
