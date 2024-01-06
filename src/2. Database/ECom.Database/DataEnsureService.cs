using ECom.Foundation.Static;

namespace ECom.Database;

public class DataEnsureService
{
  private readonly EComDbContext _dbContext;

  public DataEnsureService() {
    _dbContext = new EComDbContext();
  }

  public void Ensure() {
    EnsureCompanyInformationExists();
    EnsureOptionExists();
    EnsureAdminRoleExists();
    EnsureAdminExists();
    //stop tracking
    _dbContext.ChangeTracker.Clear();
    //close connection
    _dbContext.Dispose();
  }

  private void EnsureAdminExists() {
    if (_dbContext.Admins.Any()) return;
    _dbContext.Admins.AddRange(SeedData.Admins);
    _dbContext.SaveChanges();
  }

  private void EnsureOptionExists() {
    if (_dbContext.Options.Any()) return;
    _dbContext.Options.Add(SeedData.Option);
    _dbContext.SaveChanges();
  }

  private void EnsureCompanyInformationExists() {
    if (_dbContext.CompanyInformations.Any()) return;
    _dbContext.CompanyInformations.Add(SeedData.CompanyInformation);
    _dbContext.SaveChanges();
  }


  private void EnsureAdminRoleExists() {
    if (_dbContext.Roles.Any()) {
      EnsureAdminRoleHasPermissions();
      return;
    }

    _dbContext.Roles.Add(SeedData.OwnerRole);
    _dbContext.SaveChanges();

    void EnsureAdminRoleHasPermissions() {
      var adminRole = _dbContext.Roles.Include(x => x.PermissionRoles)
                                .FirstOrDefault(x => x.Id == Role.OWNER_ROLE_ID);
      if (adminRole == null) return;
      var isCountMatch = adminRole.PermissionRoles.Count == StaticValues.ADMIN_PERMISSION_TYPES.Count;
      if (isCountMatch) return;
      adminRole.PermissionRoles = SeedData.OwnerPermissionRoles;
      _dbContext.Roles.Update(adminRole);
      _dbContext.SaveChanges();
    }
  }
}