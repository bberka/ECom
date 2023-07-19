using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class CompanyInformationRepository : GenericRepository<CompanyInformation, EComDbContext>
{
  public CompanyInformationRepository(EComDbContext context) : base(context) {
  }
}