namespace ECom.WebApi.Endpoints.Announcement;

[AllowAnonymous]
[EndpointRoute(typeof(ListAnnouncementEndpoint))]
public class ListAnnouncementEndpoint : EndpointBaseSync.WithoutRequest.WithResult<List<Domain.Entities.Announcement>>
{
  private readonly IAnnouncementService _announcementService;

  public ListAnnouncementEndpoint(IAnnouncementService announcementService) {
    _announcementService = announcementService;
  }

  [HttpGet]
  [ResponseCache(Duration = 60)]
  [EndpointSwaggerOperation(typeof(ListAnnouncementEndpoint), "List all announcements")]
  public override List<Domain.Entities.Announcement> Handle() {
    return _announcementService.ListAnnouncements();
  }
}