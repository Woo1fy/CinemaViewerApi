using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CVA.Infrastructure
{
    public class ApplicationDbContextInitializer
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Initialise()
        {
            try
            {
                if (_context.Database.IsNpgsql())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        public void Seed()
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    TrySeed();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private void TrySeed()
        {
        }
    }
}
