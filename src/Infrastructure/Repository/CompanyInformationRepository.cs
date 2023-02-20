using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class CompanyInformationRepository : GenericRepository<CompanyInformation,EComDbContext>
{
    public CompanyInformationRepository(EComDbContext context) : base(context)
    {
    }
}