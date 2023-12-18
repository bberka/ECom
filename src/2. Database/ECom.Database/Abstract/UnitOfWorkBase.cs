using ECom.Foundation.Abstract;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace ECom.Database.Abstract;

public abstract class UnitOfWorkBase<TContext> : UnitOfWorkBase
  where TContext : DbContext, new()
{
  protected UnitOfWorkBase(TContext dbContext) : base(dbContext) { }
}

public abstract class UnitOfWorkBase : IUnitOfWorkBase
{
  protected readonly DbContext DbContext;

  protected UnitOfWorkBase(DbContext dbContext) {
    DbContext = dbContext;
  }

  protected bool IsDisposed { get; private set; }
  protected IDbContextTransaction? Transaction { get; private set; }
  protected bool IsTransactionBegan => Transaction != null;


  public DbActionResult SaveResult() {
    try {
      BeginTransaction();
      var hasChanges = HasChanges();
      if (!hasChanges) {
        Log.Debug("Db save failed: no changes");
        return new DbActionResult(false, false, 0, null);
      }

      var affectedRows = DbContext.SaveChanges();
      if (affectedRows > 0) {
        Transaction!.CommitAsync();
        Log.Debug("Db saved successfully");
        return new DbActionResult(true, false, affectedRows, null);
      }

      Transaction!.Rollback();
      Log.Debug("Db save failed: affected rows 0");
      return new DbActionResult(false, true, 0, null);
    }
    catch (Exception ex) {
      Transaction!.Rollback();
      Log.Fatal(ex, "InternalDbError");
      return new DbActionResult(false, true, 0, ex);
    }
    finally {
      ResetTransaction();
    }
  }

  public async Task<DbActionResult> SaveResultAsync() {
    try {
      await BeginTransactionAsync();
      var hasChanges = HasChanges();
      if (!hasChanges) return new DbActionResult(false, false, 0, null);

      var affectedRows = await DbContext.SaveChangesAsync();
      if (affectedRows > 0) {
        await Transaction!.CommitAsync();
        return new DbActionResult(true, false, affectedRows, null);
      }

      await Transaction!.RollbackAsync();
      return new DbActionResult(false, true, 0, null);
    }
    catch (Exception ex) {
      await Transaction!.RollbackAsync();
      return new DbActionResult(false, true, 0, ex);
    }
    finally {
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
    if (!DbContext.ChangeTracker.AutoDetectChangesEnabled) throw new InvalidOperationException("DbSave can not be called if auto detect changes is off");
    return DbContext.ChangeTracker.HasChanges();
  }


  public void Dispose() {
    IsDisposed = true;
    DbContext.Dispose();
    Transaction?.Dispose();
    Transaction = null;
    GC.SuppressFinalize(this);
  }


  protected void BeginTransaction() {
    if (IsTransactionBegan) return;
    Transaction = DbContext.Database.BeginTransaction();
  }

  protected async Task BeginTransactionAsync() {
    if (IsTransactionBegan) return;
    Transaction = await DbContext.Database.BeginTransactionAsync();
  }


  protected void ResetTransaction() {
    if (!IsTransactionBegan) return;
    Transaction?.Dispose();
    Transaction = null;
  }
}