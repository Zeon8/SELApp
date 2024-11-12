namespace SELApp
{
    public record ClassTime(TimeOnly StartTime, TimeOnly EndTime)
    {
        private static readonly Dictionary<int, ClassTime> s_classTime = new()
        {
            {1, new ClassTime(new TimeOnly(8,30,0), new TimeOnly(9,50,0))},
            {2, new ClassTime(new TimeOnly(10,0,0), new TimeOnly(11,20,0))},
            {3, new ClassTime(new TimeOnly(11,30,0), new TimeOnly(12,50,0))},
            {4, new ClassTime(new TimeOnly(13,10,0), new TimeOnly(14,30,0))},
            {5, new ClassTime(new TimeOnly(14,40,0), new TimeOnly(16,00,0))},
            {6, new ClassTime(new TimeOnly(16,10,0), new TimeOnly(17,30,0))},
        };
        
        public static ClassTime GetClassTime(int classOrder)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(classOrder, s_classTime.Count, nameof(classOrder));
            return s_classTime[classOrder];
        }
    }
}
