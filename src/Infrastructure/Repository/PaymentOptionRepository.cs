using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class PaymentOptionRepository : RepositoryBase<PaymentOption>
{
  public PaymentOptionRepository(DbContext context) : base(context) {
  }
}