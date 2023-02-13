namespace ECom.Domain.Abstract;

public interface ISupplierService
{
    List<Supplier> ListSuppliers();

    bool Exists(int id);

    ResultData<Supplier> Get(int id);
    Result Update(Supplier supplier);
    Result Delete(int id);

}