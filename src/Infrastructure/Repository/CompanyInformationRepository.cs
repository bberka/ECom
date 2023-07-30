using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CompanyInformationRepository : RepositoryBase<CompanyInformation>
{
  public CompanyInformationRepository(DbContext context) : base(context) {
  }
}