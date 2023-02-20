namespace ECom.Infrastructure.Repository;

public class ShowCaseImageRepository : GenericRepository<ShowCaseImage,EComDbContext>
{
    public ShowCaseImageRepository(EComDbContext context) : base(context)
    {
    }
}