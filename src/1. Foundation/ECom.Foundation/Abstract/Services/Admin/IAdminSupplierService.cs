using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminSupplierService
{
  List<Supplier> GetSuppliers();
  Result<Supplier> GetSupplier(int id);
  Result UpdateSupplier(Supplier supplier);
  Result DeleteSupplier(int id);
}