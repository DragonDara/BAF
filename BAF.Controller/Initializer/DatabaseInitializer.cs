using BAF.DataAccess.SqlServer;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BAF.Controller.Initializer
{
    public class DatabaseInitializer : IAsyncInitializer
    {
        private readonly ApplicationDbContext _applciationDbContext;

        public DatabaseInitializer(ApplicationDbContext applciationDbContext)
        {
            _applciationDbContext = applciationDbContext;
        }

        public async Task InitializeAsync()
        {
            await _applciationDbContext.Database.MigrateAsync();
        }
    }
}
