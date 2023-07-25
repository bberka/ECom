namespace ECom.Domain.Abstract;

public interface IUnitOfWorkBase : IDisposable
{
    bool Save();
    Task<bool> SaveAsync();
    DbActionResult SaveResult();
    Task<DbActionResult> SaveResultAsync();
    int SaveChanges();
    Task<int> SaveChangesAsync();
    bool HasChanges();

}

