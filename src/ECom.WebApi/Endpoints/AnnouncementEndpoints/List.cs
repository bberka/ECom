using ECom.Application.Attributes;

namespace ECom.WebApi.Endpoints.AnnouncementEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(List))]
public class List : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Announcement>>
{
  private readonly IAnnouncementService _announcementService;

  public List(IAnnouncementService announcementService) {
    _announcementService = announcementService;
  }

  [HttpGet]
  [ResponseCache(Duration = 60)]
  [EndpointSwaggerOperation(typeof(List), "List all announcements")]
  public override List<Domain.Entities.Announcement> Handle() {
    return _announcementService.ListAnnouncements();
  }
}