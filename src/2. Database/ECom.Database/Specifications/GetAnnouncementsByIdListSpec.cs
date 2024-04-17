using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetAnnouncementsByIdListSpec : ISpecification<Announcement>
{
  private readonly Guid[] _ids;

  public GetAnnouncementsByIdListSpec(Guid[] ids) {
    _ids = ids;
  }

  public IQueryable<Announcement> GetQuery(IQueryable<Announcement> inputQuery) {
    return inputQuery.Where(x => _ids.Contains(x.Id));
  }
}