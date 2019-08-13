using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DependencyInjection.Database.Seeding
{
    public class Restaurant
    {
        public static Builder New()
        {
            return new Builder();
        }

        public Restaurant(
            IReadOnlyList<Table> tables,
            IReadOnlyList<Shift> shifts,
            IReadOnlyList<Reservation> reservations)
        {
            Tables = tables;
            Shifts = shifts;
            Reservations = reservations;
        }

        public IReadOnlyList<Table> Tables { get; }
        public IReadOnlyList<Shift> Shifts { get; }
        public IReadOnlyList<Reservation> Reservations { get; }

        public class Builder
        {
            private readonly List<Table> _tables;
            private readonly List<Shift> _shifts;
            private readonly List<ReservationSpec> _reservations;

            public Builder()
            {
                _tables = new List<Table>();
                _shifts = new List<Shift>();
                _reservations = new List<ReservationSpec>();
            }

            public Builder Tables(
                params string[] names)
            {
                _tables.AddRange(names.Select(name => new Table()
                {
                    Name = name
                }));

                return this;
            }

            public Builder Shift(
                string name,
                string starts,
                string ends)
            {
                _shifts.Add(new Shift()
                {
                    Name = name,
                    StartsAt = AsTime(starts),
                    EndsAt = AsTime(ends)
                });

                return this;
            }

            public Builder Reservation(
                string name,
                DateTime on,
                string at,
                IReadOnlyList<string> assignedTo)
            {
                return Reservation(name, on.ToString("yyyy-MM-dd"), at, assignedTo);
            }

            public Builder Reservation(
                string name,
                string on,
                string at,
                IReadOnlyList<string> assignedTo)
            {
                _reservations.Add(new ReservationSpec(
                    name,
                    AsDateTime(on, at),
                    assignedTo
                ));

                return this;
            }

            private static DateTime AsDateTime(string date, string time) =>
                AsDate(date) + AsTime(time);

            private static DateTime AsDate(string date) =>
                DateTime.Parse(date, CultureInfo.InvariantCulture).Date;

            private static TimeSpan AsTime(string time) =>
                DateTime.Parse(time, CultureInfo.InvariantCulture).TimeOfDay;

            public Restaurant Build()
            {
                var tablesByName = _tables.ToDictionary(t => t.Name);
                var reservations = _reservations.Select(r => r.ToReservation(tablesByName)).ToList();
                return new Restaurant(_tables, _shifts, reservations);
            }
        }

        private class ReservationSpec
        {
            public ReservationSpec(
                string reserverName,
                DateTime reservationTime,
                IReadOnlyList<string> assignedTableNames)
            {
                ReserverName = reserverName;
                ReservationTime = reservationTime;
                AssignedTableNames = assignedTableNames;
            }

            public string ReserverName { get; }
            public DateTime ReservationTime { get; }
            public IReadOnlyList<string> AssignedTableNames { get; }

            public Reservation ToReservation(IReadOnlyDictionary<string, Table> tablesByName)
            {
                return new Reservation()
                {
                    ReserverName = ReserverName,
                    ReservationTime = ReservationTime,
                    TableAssignments = AssignedTableNames
                        .Select(tableName => new TableAssignment()
                        {
                            Table = tablesByName[tableName]
                        })
                        .ToList()
                };
            }
        }
    }
}
