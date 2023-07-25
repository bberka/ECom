using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminSupplierService
{
    List<Supplier> GetSuppliers();
    CustomResult<Supplier> GetSupplier(int id);
    CustomResult UpdateSupplier(Supplier supplier);
    CustomResult DeleteSupplier(int id);
}