using ECom.Database.Abstract;

namespace ECom.Database.Specifications;

public sealed record GetAnnouncementsByIdSpec : ISpecification<Announcement>
{
  private readonly Guid _guid;

  public GetAnnouncementsByIdSpec(Guid guid) {
    _guid = guid;
  }

  public IQueryable<Announcement> GetQuery(IQueryable<Announcement> inputQuery) {
    return inputQuery.Where(x => x.Id == _guid);
  }
}