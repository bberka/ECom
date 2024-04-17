using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetAdminByEmailSpec : ISpecification<Admin>
{
  private readonly bool _allowDeleted;
  private readonly string _email;

  public GetAdminByEmailSpec(string email, bool allowDeleted = false) {
    _email = email;
    _allowDeleted = allowDeleted;
  }

  public IQueryable<Admin> GetQuery(IQueryable<Admin> inputQuery) {
    inputQuery = inputQuery
                 .Where(x => x.EmailAddress == _email)
                 .Include(x => x.Role)
                 .Include(x => x.Role.PermissionRoles);

    if (!_allowDeleted) {
      inputQuery = inputQuery.Where(x => x.DeleteDate.HasValue == false);
    }

    return inputQuery;
  }
}