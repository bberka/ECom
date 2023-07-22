using ECom.Domain.EfAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECom.Infrastructure.Abstract;

public abstract class UnitOfWorkBase<TContext> : UnitOfWorkBase
  where TContext : DbContext, new()
{
  protected UnitOfWorkBase(TContext dbContext) : base(dbContext) {
  }
}

public abstract class UnitOfWorkBase : IUnitOfWorkBase
{
  protected readonly DbContext DbContext;
  protected bool IsDisposed { get; private set; } = false;
  protected IDbContextTransaction? Transaction { get; private set; }
  protected bool IsTransactionBegan { get; private set; }

  protected UnitOfWorkBase(DbContext dbContext) {
    DbContext = dbContext;
    IsTransactionBegan = false;
  }
  public DbActionResult SaveResult() {
    try {
      BeginTransaction();
      var hasChanges = HasChanges();
      if (!hasChanges) {
        return new DbActionResult(false, false, 0, null);
      }
      var affectedRows = DbContext.SaveChanges();
      if (affectedRows > 0) {
        Transaction!.CommitAsync();
        return new DbActionResult(true, false, affectedRows, null);
      }
      Transaction!.Rollback();
      return new DbActionResult(false, true, 0, null);
    } catch (Exception ex) {
      Transaction!.Rollback();
      return new DbActionResult(false, true, 0, ex);
    } finally {
      ResetTransaction();
    }
  }

  public async Task<DbActionResult> SaveResultAsync() {

    try {
      await BeginTransactionAsync();
      var hasChanges = HasChanges();
      if (!hasChanges) {
        return new DbActionResult(false, false, 0, null);
      }
      var affectedRows = await DbContext.SaveChangesAsync();
      if (affectedRows > 0) {
        await Transaction!.CommitAsync();
        return new DbActionResult(true, false, affectedRows, null);
      }
      await Transaction!.RollbackAsync();
      return new DbActionResult(false, true, 0, null);
    } catch (Exception ex) {
      await Transaction!.RollbackAsync();
      return new DbActionResult(false, true, 0, ex);
    } finally {
      ResetTransaction();
    }
  }



  public bool Save() {
    var result = SaveResult();
    return result.Status;
  }

  public async Task<bool> SaveAsync() {
    var result = await SaveResultAsync();
    return result.Status;
  }



  public int SaveChanges() {
    var result = SaveResult();
    return result.AffectedRows;
  }

  public async Task<int> SaveChangesAsync() {
    var result = await SaveResultAsync();
    return result.AffectedRows;
  }



  public bool HasChanges() {
    return DbContext.ChangeTracker.HasChanges();
  }


  public void Dispose() {
    IsDisposed = true;
    DbContext.Dispose();
    Transaction?.Dispose();
    GC.SuppressFinalize(this);
  }


  protected void BeginTransaction() {
    if (IsTransactionBegan) return;
    IsTransactionBegan = true;
    Transaction = DbContext.Database.BeginTransaction();
  }

  protected async Task BeginTransactionAsync() {
    if (IsTransactionBegan) return;
    IsTransactionBegan = true;
    Transaction = await DbContext.Database.BeginTransactionAsync();
  }


  protected void ResetTransaction() {
    if (!IsTransactionBegan) return;
    Transaction = null;
    IsTransactionBegan = false;
  }
}