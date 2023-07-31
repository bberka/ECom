namespace ECom.Infrastructure;

public class DataEnsureService
{
  private readonly EComDbContext _dbContext;

  public DataEnsureService() {
    _dbContext = new EComDbContext();
  }

  public void Ensure() {
    ValidatePermissions();
    EnsureCompanyInformationExists();
    EnsureOptionExists();
    EnsureAdminRoleExists();
    EnsureAdminExists();
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


  private void ValidatePermissions() {
    var perms = _dbContext.Permissions.ToList();
    if (perms.Count == 0) _dbContext.Permissions.AddRange(SeedData.Permissions);
    else if (perms.Count != SeedData.Permissions.Count) {
      _dbContext.Permissions.RemoveRange(perms);
      _dbContext.Permissions.AddRange(SeedData.Permissions);
    }
    else {
      var anyInvalid = false;
      foreach (var perm in perms) {
        var seedPerm = SeedData.Permissions.FirstOrDefault(x => x.Id == perm.Id);
        if (seedPerm == null) {
          anyInvalid = true;
          break;
        }

        if (perm.Id != seedPerm.Id) {
          anyInvalid = true;
          break;
        }
      }

      if (anyInvalid) {
        _dbContext.Permissions.RemoveRange(perms);
        _dbContext.Permissions.AddRange(SeedData.Permissions);
      }
    }
    _dbContext.SaveChanges();
  }
  private void EnsureAdminRoleExists() {
    if (_dbContext.Roles.Any()) {
      EnsureAdminRoleHasPermissions();
      return;
    }
    _dbContext.Roles.Add(SeedData.AdminRole);
    _dbContext.SaveChanges();

    void EnsureAdminRoleHasPermissions() {
      var adminRole = _dbContext.Roles.Include(x => x.Permissions).FirstOrDefault(x => x.Id == SeedData.AdminRole.Id);
      if (adminRole == null) return;
      var permissions = _dbContext.Permissions.ToList();
      adminRole.Permissions = permissions;
      _dbContext.SaveChanges();
    }
  }

}