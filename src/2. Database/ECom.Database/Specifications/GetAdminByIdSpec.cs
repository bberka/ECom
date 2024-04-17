using System.Linq.Expressions;
using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetAdminByIdSpec : ISpecification<Admin>
{
  private readonly bool _allowDeleted;
  private readonly Guid _id;

  public GetAdminByIdSpec(Guid id, bool allowDeleted = false) {
    _id = id;
    _allowDeleted = allowDeleted;
  }

  public IQueryable<Admin> GetQuery(IQueryable<Admin> inputQuery) {
    inputQuery = inputQuery
                 .Where(x => x.Id == _id)
                 .Include(x => x.Role)
                 .Include(x => x.Role.PermissionRoles);
    if (!_allowDeleted) {
      inputQuery = inputQuery.Where(x => x.DeleteDate.HasValue == false);
    }

    return inputQuery;
  }
}