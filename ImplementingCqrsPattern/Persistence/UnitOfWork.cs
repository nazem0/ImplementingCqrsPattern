using Microsoft.EntityFrameworkCore.Storage;

namespace ImplementingCqrsPattern.Persistence
{
    public class UnitOfWork(AppDbContext _dbContext)
    {
        public int SaveChanges()
        {
            using IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            int changes = _dbContext.SaveChanges();
            transaction.Commit();
            return changes;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            using IDbContextTransaction transaction =
                await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            int changes = await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return changes;
        }
    }
}
