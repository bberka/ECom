using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetCargoOptionByIdSpec : ISpecification<CargoOption>
{
  private readonly Guid _id;

  public GetCargoOptionByIdSpec(Guid id) {
    _id = id;
  }

  public IQueryable<CargoOption> GetQuery(IQueryable<CargoOption> inputQuery) {
    return inputQuery.Where(x => x.Id == _id);
  }
}