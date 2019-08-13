using DependencyInjection.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class ReportGenerator
    {
        private readonly string _connectionString;

        public ReportGenerator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IReadOnlyList<string>> TodayReservationsAsync(IReadOnlyList<Reservation> Reservations, // LoadReservationsForDateAsync
                                                 IReadOnlyList<Shift> Shifts, DateTime dataTime) //await context.Shifts.ToListAsync()
        {
            List<string> ListFileNames = new List<string>();
            foreach (var shift in Shifts)
            {
                var reservationsInShift = FilterReservationsInShift(shift, Reservations);

                ListFileNames.Add(GenerateReportFileName(shift, dataTime.Date));
                    
            }
            return ListFileNames;
        }
        // не трогать, загрузка из ДБ только
        public async Task<IReadOnlyList<Reservation>> LoadReservationsForDateAsync(
            RestaurantContext context,
            DateTime date)
        {
            var beginingOfDay = date.Date;
            var endOfDay = beginingOfDay.AddDays(1);

            var reservations = 
                from r in context.Reservations
                where beginingOfDay <= r.ReservationTime && r.ReservationTime < endOfDay
                select r;

            return await reservations
                .Include(r => r.TableAssignments)
                .ThenInclude(ta => ta.Table)
                .ToListAsync();
        }
        /// TODO :
        /// нужно сделать так, чтобы все функции были лишь по мнимым аргументам, 
        /// тогда мы добьемся определенной изоляции
        /// появится возможность по частям делать код
        /// сделать его рабочим
        /// после этого
        /// можно его еще раз рефакторить с использованием паттеров
        /// и когда он будет рабочим и в паттернах
        /// мы сможем делать юнит тест для функций, которые будут самыми высокоуровневыми
        public async Task<IReadOnlyList<Reservation>> GetReservations(DateTime dataTime)
        {
            List<Reservation> ResultList;
            using (var context = GenerateSessionContext(_connectionString))
            {
                ResultList = await LoadReservationsForDateAsync(new RestaurantContext(_connectionString), dataTime);
            }
            return null;
        }
        private async Task<RestaurantContext> GenerateSessionContext(string connection)
        {
            return new RestaurantContext(connection);
        }

        // не трогать, только возвращает из дб лист
        private IReadOnlyList<Reservation> FilterReservationsInShift(
            Shift shift,
            IReadOnlyList<Reservation> reservations)
        {
            return reservations
                .Where(r => shift.StartsAt <= r.ReservationTime.TimeOfDay && 
                            r.ReservationTime.TimeOfDay <= shift.EndsAt)
                .ToList();
        }

        private string GenerateReportFileName(Shift shift, DateTime date)
        {
            return $"{date.ToString("yyyyMMdd")}_{shift.Name}.txt";
        }
        // просто генерирует файл
        private async Task GenerateReportContentAsync(
            string reportFileName,
            Shift shift,
            DateTime date,
            IReadOnlyList<Reservation> reservationsInShift)
        {
                using (var writer = new StreamWriter(File.OpenWrite(reportFileName))) 
            {
                writer.WriteLine($"{Date(date)} {TimeOfDay(shift.StartsAt)}-{TimeOfDay(shift.EndsAt)}");
                writer.WriteLine($"Shift '{shift.Name}'");
                writer.WriteLine("-------------------------------------------------");

                var partyNumber = 1;
                foreach (var reservation in reservationsInShift.OrderBy(r => r.ReservationTime))
                {
                    var tableNames = reservation.TableAssignments.Select(t => t.Table.Name);

                    writer.Write($"{partyNumber}. {TimeOfDay(reservation.ReservationTime)} ");
                    writer.Write($"{reservation.ReserverName} (tables: {string.Join(", ", tableNames)})");
                    writer.WriteLine();

                    partyNumber++;
                }

                await writer.FlushAsync();
            }
        }

        private static string Date(DateTime dateTime) =>
            dateTime.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture);

        private static string TimeOfDay(TimeSpan timeSpan) =>
            TimeOfDay(DateTime.Today + timeSpan);

        private static string TimeOfDay(DateTime dateTime) =>
            dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
    }
}
