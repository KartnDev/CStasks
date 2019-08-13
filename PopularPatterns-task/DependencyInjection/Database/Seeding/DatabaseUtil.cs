using System.Threading.Tasks;

namespace DependencyInjection.Database.Seeding
{
    public static class DatabaseUtil
    {
        public static Task RecreateAndSeedAsync(string connectionString)
        {
            return RecreateAndSeedAsync(connectionString, Restaurant.New()
                .Tables("A", "B", "C")
                .Shift("Brunch", starts: "8 AM", ends: "12 PM")
                .Shift("Dinner", starts: "5 PM", ends: "11 PM")
                .Reservation("Abby", on: "2019-06-26", at: "9 AM", assignedTo: new[] { "A", "C" })
                .Reservation("Bobby", on: "2019-06-26", at: "5 PM", assignedTo: new[] { "B" })
                .Reservation("Charley", on: "2019-06-26", at: "5 PM", assignedTo: new[] { "C" }));
        }

        public static async Task RecreateAndSeedAsync(
            string connectionString,
            Restaurant.Builder restaurantBuilder)
        {
            using (var context = new RestaurantContext(connectionString))
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
                await context.SeedAsync(restaurantBuilder.Build());
            }
        }

        private static async Task SeedAsync(
            this RestaurantContext context,
            Restaurant restaurant)
        {
            context.Tables.AddRange(restaurant.Tables);
            context.Shifts.AddRange(restaurant.Shifts);
            context.Reservations.AddRange(restaurant.Reservations);

            await context.SaveChangesAsync();
        }
    }
}
