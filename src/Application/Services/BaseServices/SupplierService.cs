﻿using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class SupplierService : IAdminSupplierService
{
  protected readonly IUnitOfWork UnitOfWork;

  protected SupplierService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

  public List<Supplier> GetSuppliers() {
    return UnitOfWork.Suppliers
      
      .OrderByDescending(x => x.RegisterDate)
      .ToList();
  }

  public CustomResult<Supplier> GetSupplier(int id) {
    var supplier = UnitOfWork.Suppliers.Find(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    return supplier;
  }

  public CustomResult UpdateSupplier(Supplier supplier) {
    var exists = UnitOfWork.Suppliers.Any(x => x.Id == supplier.Id);
    if (!exists) return DomainResult.NotFound(nameof(Supplier));
    UnitOfWork.Suppliers.Update(supplier);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSupplier));
    return DomainResult.OkUpdated(nameof(Supplier));
  }

  public CustomResult DeleteSupplier(int id) {
    var supplier = UnitOfWork.Suppliers.Find(id);
    if (supplier is null) return DomainResult.NotFound(nameof(Supplier));
    UnitOfWork.Suppliers.Remove(supplier);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError("DeleteSupplier");
    return DomainResult.OkDeleted("Supplier");
  }
}