namespace ECom.Application.Services;

public class SupplierService : ISupplierService
{
  private readonly IUnitOfWork _unitOfWork;

  public SupplierService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public List<Supplier> ListSuppliers() {
    return _unitOfWork.SupplierRepository
      .Get()
      .OrderByDescending(x => x.RegisterDate)
      .ToList();
  }

  public bool Exists(int id) {
    return _unitOfWork.SupplierRepository.Any(x => x.Id == id);
  }

  public ResultData<Supplier> Get(int id) {
    var supplier = _unitOfWork.SupplierRepository.GetById(id);
    if (supplier is null) return DomainResult.Supplier.NotFoundResult();
    return supplier;
  }

  public Result Update(Supplier supplier) {
    var exist = Exists(supplier.Id);
    if (!exist) return DomainResult.Supplier.NotFoundResult();
    _unitOfWork.SupplierRepository.Update(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Supplier.UpdateSuccessResult();
  }

  public Result Delete(int id) {
    var supplier = _unitOfWork.SupplierRepository.GetById(id);
    if (supplier is null) return DomainResult.Supplier.NotFoundResult();
    _unitOfWork.SupplierRepository.Delete(supplier);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Supplier.DeleteSuccessResult();
  }
}