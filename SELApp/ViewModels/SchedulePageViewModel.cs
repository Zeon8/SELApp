using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SELApp.Models.Schedule;
using SELApp.Services;

namespace SELApp.ViewModels
{
    public partial class SchedulePageViewModel : ObservableObject
    {
        public bool IsLoading => Schedule is null;

        public IEnumerable<DaySchedule>? Schedule => _daySchedule?
            .Where(s => s.Date >= _todayDate || IsAllShown);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Schedule))]
        private bool _isAllShown;

        private IEnumerable<DaySchedule>? _daySchedule;
        private Schedule? _serverSchedule;
        private readonly DateOnly _todayDate = DateOnly.FromDateTime(DateTime.Today);
        private readonly ScheduleService _scheduleService;

        public SchedulePageViewModel(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task Load()
        {
            _serverSchedule = await _scheduleService.GetSchedule();
            if (_serverSchedule is null)
                return;

            _daySchedule = _serverSchedule.Classes
                .Take(100)
                .OrderBy(c => c.Date)
                .ThenBy(c => c.ClassNumber)
                .GroupBy(key => key.Date)
                .Select(group => new DaySchedule(DateOnly.FromDateTime(group.Key), group));

            OnPropertyChanged(nameof(Schedule));
            OnPropertyChanged(nameof(IsLoading));
        }

        [RelayCommand]
        private Task Save()
        {
            if(_serverSchedule is not null)
                return _scheduleService.SaveSchedule(_serverSchedule);
            return Task.CompletedTask;
        }

        [RelayCommand]
        private void ToggleIsAllShown() => IsAllShown = !IsAllShown;
    }
}
