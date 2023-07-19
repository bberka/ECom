using ECom.Domain.Entities;

namespace ECom.Application.SharedEndpoints.AnnouncementEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Announcement>>
{
  private readonly IAnnouncementService _announcementService;

  public List(IAnnouncementService announcementService) {
    _announcementService = announcementService;
  }

  [HttpGet]
  [ResponseCache(Duration = 60)]
  [EndpointSwaggerOperation(typeof(List), "List all announcements")]
  public override List<Announcement> Handle() {
    return _announcementService.ListAnnouncements();
  }
}