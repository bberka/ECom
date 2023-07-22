namespace ECom.Domain.EfAbstractions;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Persists current changes to database in a transaction 
    /// </summary>
    /// <returns></returns>
    int SaveChanges();
    int SaveChangesCatch(out Exception? exception);
    Task<int> SaveChangesAsync();
    bool HasChanges();
    void BeginTransaction();
    Task BeginTransactionAsync();


}