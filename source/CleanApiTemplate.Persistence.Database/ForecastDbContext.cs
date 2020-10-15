using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using CleanApiTemplate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanApiTemplate.Persistence.Database
{
    public class ForecastDbContext : DbContext, IForecastDbContext
    {
        private IDbContextTransaction _currentTransaction;

        public ForecastDbContext(DbContextOptions<ForecastDbContext> options) :
            base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<Location> Locations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
