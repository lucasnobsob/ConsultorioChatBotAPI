using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsultorioChatBot.Business.Helpers
{
    public class DateHelper
    {
        public static IEnumerable<(int, DateOnly)> GetDaysOfWeek()
        {
            return Enumerable.Range(1, 5).Select(i => (i, DateOnly.FromDateTime(DateTime.Now.AddDays(i - 1)))).ToList();
        }

        public static IEnumerable<(int, DateTime)> GetHoursOfDay(IEnumerable<DateTime> diffDates, DateOnly data)
        {
            var datesList = Enumerable.Range(0, 5).SelectMany(dayOffset => Enumerable.Range(8, 5)
                .Select(hour => DateTime.Today.AddDays(dayOffset).AddHours(hour))).ToList();
            var diasAgendados = diffDates.GroupBy(x => x).Select(g => g.Key).ToList();
            var horarios = datesList.Where(date => !diasAgendados.Contains(date) && DateOnly.FromDateTime(date) == data).ToList();

            return horarios.Select((data, indice) => (indice, data)).ToList();
        }
    }
}
