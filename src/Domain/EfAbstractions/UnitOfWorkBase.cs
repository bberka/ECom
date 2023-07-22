using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECom.Domain.EfAbstractions;

public abstract class UnitOfWorkBase<T> : IUnitOfWork
   where T : DbContext
{
    private readonly T _dbContext;
    private IDbContextTransaction? _transaction;
    protected bool IsTransactionBegan { get; private set; }

    protected UnitOfWorkBase(T dbContext)
    {
        _dbContext = dbContext;
        IsTransactionBegan = false;
    }

    public virtual int SaveChanges()
    {
        if (!HasChanges()) return 0;
        BeginTransaction();
        var affectedRows = _dbContext.SaveChanges();
        if (affectedRows == 0)
            _transaction!.Rollback();
        else _transaction!.Commit();
        ResetTransaction();

        return affectedRows;
    }

    public virtual int SaveChangesCatch(out Exception? exception)
    {
        exception = null;
        try
        {
            if (!HasChanges()) return 0;
            BeginTransaction();
            var affectedRows = _dbContext.SaveChanges();
            if (affectedRows == 0)
                _transaction!.Rollback();
            else
                _transaction!.Commit();
            ResetTransaction();

            return affectedRows;
        }
        catch (Exception ex)
        {
            exception = ex;
            _transaction!.Rollback();
            ResetTransaction();

            return 0;
        }
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        if (!HasChanges()) return 0;
        await BeginTransactionAsync();
        var affectedRows = await _dbContext.SaveChangesAsync();
        if (affectedRows == 0)
            await _transaction!.RollbackAsync();
        else
            await _transaction!.CommitAsync();
        ResetTransaction();
        return affectedRows;
    }

    public bool HasChanges()
    {
        return _dbContext.ChangeTracker.HasChanges();
    }

    public void BeginTransaction()
    {
        if (IsTransactionBegan) return;
        IsTransactionBegan = true;
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public async Task BeginTransactionAsync()
    {
        if (IsTransactionBegan) return;
        IsTransactionBegan = true;
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        _transaction?.Dispose();
        GC.SuppressFinalize(this);
    }

    protected void ResetTransaction()
    {
        _transaction = null;
        IsTransactionBegan = false;
    }
}