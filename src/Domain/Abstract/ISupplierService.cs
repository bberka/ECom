using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface ISupplierService
{
  List<Supplier> GetSuppliers();
  CustomResult<Supplier> GetSupplier(int id);
  CustomResult UpdateSupplier(Supplier supplier);
  CustomResult DeleteSupplier(int id);
}