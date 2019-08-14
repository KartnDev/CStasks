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


        private async Task<IReadOnlyList<Shift>> GetShiftsAsync(RestaurantContext context)
        {
            return await context.Shifts.ToListAsync();
        }

        public async Task GenerateAllReportContent(DateTime dateTime, RestaurantContext context)
        {
            var ReservationList = await LoadReservationsForDateAsync(context, dateTime);
            var Shifts = await GetShiftsAsync(context);
            var General_Instances = await TodayReservationsAsync(ReservationList, Shifts, dateTime);

            foreach(var tuple in General_Instances)
            {
                await GenerateReportContentAsync(tuple.Item4, tuple.Item1, tuple.Item2, tuple.Item3);
            }
        }




        private async Task<List<Tuple<Shift, DateTime, IReadOnlyList<Reservation>, string>>> TodayReservationsAsync(IReadOnlyList<Reservation> Reservations, 
                                                 IReadOnlyList<Shift> Shifts, 
                                                 DateTime NowDateTime) // after this await GenerateReportContentAsync(stream, shift, date, reservationsInShift);
        {
            var Result = new List<Tuple<Shift, DateTime, IReadOnlyList<Reservation>, string>>();

            foreach (var shift in Shifts)
            {
                var reservationsInShift = FilterReservationsInShift(shift, Reservations);

                var reportFileName = GenerateReportFileName(shift, NowDateTime);
                    
                Result.Add(new Tuple<Shift, DateTime, IReadOnlyList<Reservation>, string>(shift, NowDateTime, reservationsInShift, reportFileName));

            }
            return Result;
        }

        private async Task<IReadOnlyList<Reservation>> LoadReservationsForDateAsync(
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

        private async Task GenerateReportContentAsync(
            string path,
            Shift shift,
            DateTime date,
            IReadOnlyList<Reservation> reservationsInShift)
        {
            using (var writer = new StreamWriter(File.OpenWrite(path))) 
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
