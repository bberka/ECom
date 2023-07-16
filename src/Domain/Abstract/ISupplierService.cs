namespace ECom.Domain.Abstract;

public interface ISupplierService
{
  List<Supplier> ListSuppliers();

  bool Exists(int id);

  CustomResult<Supplier> Get(int id);
  CustomResult Update(Supplier supplier);
  CustomResult Delete(int id);
}