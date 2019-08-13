using DependencyInjection.Database.Seeding;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace DependencyInjection.Tests
{
    [TestClass]
    public class ReportGeneratorTests
    {
        private const string ConnectionString =
            @"Server=LAPTOP-TBO8G4T7\SQLEXPRESS;Database=Restaurant;Trusted_Connection=True;";

        [TestMethod]
        public async Task TodayReservations_OneShift_GeneratesFilePerShift()
        {
            // arrange
            var today = new DateTime(19, 01, 23);

            await DatabaseUtil.RecreateAndSeedAsync(ConnectionString, Restaurant.New()
                .Tables("Table A")
                .Shift("Lunch", starts: "10 AM", ends: "11 AM")
                .Reservation("Abby", on: today, at: "10:30 AM", assignedTo: new[] { "Table A" }));

            var reportGenerator = new ReportGenerator(ConnectionString);

            // act
            await reportGenerator.TodayReservationsAsync(new List(), );

            // assert
            await AssertReportCorrectAsync(
                $"{FileNameDate(today)}_Lunch.txt",
                $"{ReportDate(today)} 10:00 AM-11:00 AM",
                "Shift 'Lunch'",
                "-------------------------------------------------",
                "1. 10:30 AM Abby (tables: Table A)");
        }

        [TestMethod]
        public async Task TodayReservations_MultipleShifts_GeneratesFilePerShift()
        {
            // arrange
            var today = DateTime.Now.Date;

            await DatabaseUtil.RecreateAndSeedAsync(ConnectionString, Restaurant.New()
                .Tables("Table A", "Table B")
                .Shift("Lunch", starts: "10 AM", ends: "11 AM")
                .Shift("Dinner", starts: "7 PM", ends: "9 PM")
                .Reservation("Abby", on: today, at: "10:30 AM", assignedTo: new[] { "Table A" })
                .Reservation("Bobby", on: today, at: "7:30 PM", assignedTo: new[] { "Table A", "Table B" })
                .Reservation("Charley", on: today, at: "7 PM", assignedTo: new[] { "Table B" })
                .Reservation("Delta", on: today, at: "3 PM", assignedTo: new[] { "Table B" }));

            var reportGenerator = new ReportGenerator(ConnectionString);

            // act
            await reportGenerator.TodayReservationsAsync();

            // assert
            await AssertReportCorrectAsync(
                $"{FileNameDate(today)}_Lunch.txt",
                $"{ReportDate(today)} 10:00 AM-11:00 AM",
                "Shift 'Lunch'",
                "-------------------------------------------------",
                "1. 10:30 AM Abby (tables: Table A)");

            await AssertReportCorrectAsync(
                $"{FileNameDate(today)}_Dinner.txt",
                $"{ReportDate(today)} 07:00 PM-09:00 PM",
                "Shift 'Dinner'",
                "-------------------------------------------------",
                "1. 07:00 PM Charley (tables: Table B)",
                "2. 07:30 PM Bobby (tables: Table A, Table B)");
        }

        private async Task AssertReportCorrectAsync(
            string fileName, 
            params string[] expectedContentLines)
        {
            File.Exists(fileName).Should().BeTrue();

            var actualContents = await File.ReadAllTextAsync(fileName);
            var expectedContents = string.Join(Environment.NewLine, expectedContentLines) + Environment.NewLine;
            actualContents.Should().Be(expectedContents);
        }

        private static string FileNameDate(DateTime date) => 
            date.ToString("yyyyMMdd");

        private static string ReportDate(DateTime date) => 
            date.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture);
    }
}
