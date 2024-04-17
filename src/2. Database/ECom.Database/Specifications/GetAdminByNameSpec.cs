using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetAdminByNameSpec : ISpecification<Admin>
{
  private readonly bool _allowDeleted;
  private readonly string _name;

  public GetAdminByNameSpec(string name, bool allowDeleted = false) {
    _name = name;
    _allowDeleted = allowDeleted;
  }

  public IQueryable<Admin> GetQuery(IQueryable<Admin> inputQuery) {
    inputQuery = inputQuery
                 .Where(x => x.FirstName == _name || x.LastName == _name)
                 .Include(x => x.Role)
                 .Include(x => x.Role.PermissionRoles);

    if (!_allowDeleted) {
      inputQuery = inputQuery.Where(x => x.DeleteDate.HasValue == false);
    }

    return inputQuery;
  }
}