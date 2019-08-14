using DependencyInjection.Database.Seeding;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {




        private const string ConnectionString =
            @"Server=LAPTOP-TBO8G4T7\SQLEXPRESS;Database=Restaurant;Trusted_Connection=True;";

        static async Task Main(string[] args)
        {
            await DatabaseUtil.RecreateAndSeedAsync(ConnectionString);

            var reportGenerator = new ReportGenerator(ConnectionString);
            await reportGenerator.GenerateAllReportContent(new System.DateTime(), 
                                                          new Database.RestaurantContext(ConnectionString));
        }
    }
}
