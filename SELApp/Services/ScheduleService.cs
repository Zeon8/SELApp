using SELApp.Models;
using SELApp.Models.Schedule;
using System.Net.Http.Json;
using System.Text;

namespace SELApp.Services
{
    public class ScheduleService
    {
        private readonly HttpClient _client;
        private readonly SessionStorageService _sessionService;

        public ScheduleService(HttpClient client, SessionStorageService sessionService)
        {
            _client = client;
            _sessionService = sessionService;
        }

        public async Task<Schedule?> GetSchedule()
        {
            User user = (await _sessionService.GetUser())!;
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {user.FirebaseToken}");
            return await _client.GetFromJsonAsync<Schedule>("api/schedule");
        }

        public async Task SaveSchedule(Schedule schedule)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "schedule.ics");
            if (File.Exists(path))
                File.Delete(path);

            await using (var file = File.Create(path))
            {
                var writer = new StreamWriter(file);
                writer.WriteLine("BEGIN:VCALENDAR");
                writer.WriteLine("NAME:Розклад пар");
                foreach (var @class in schedule.Classes.Take(100))
                {
                    var classTime = ClassTime.GetClassTime(@class.ClassNumber);
                    writer.WriteLine("BEGIN:VEVENT");
                    writer.WriteLine($"SUMMARY: {@class.ClassNumber} пара {@class.SubjectName} {@class.AuditoryName}");
                    writer.WriteLine($"DTSTART:{@class.Date: yyyyMMdd}T{classTime.StartTime:HHmmss}");
                    writer.WriteLine($"DTEND:{@class.Date: yyyyMMdd}T{classTime.EndTime:HHmmss}");
                    writer.WriteLine("END:VEVENT");
                }
                writer.WriteLine("END:VCALENDAR");
                await writer.FlushAsync();
            }
            await Launcher.OpenAsync(new OpenFileRequest("Зберегти розклад", new ReadOnlyFile(path)));
        }
    }
}
