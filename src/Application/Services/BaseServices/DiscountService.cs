using ECom.Domain.Abstract.Services.Base;

namespace ECom.Application.Services.BaseServices;

public abstract class DiscountService : IDiscountService
{
    private readonly IUnitOfWork UnitOfWork;

    protected DiscountService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}