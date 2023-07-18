namespace ECom.Application.SharedEndpoints.OptionEndpoints;

[AllowAnonymous]
[EndpointRoute(typeof(GetCategories))]
public class GetCategories : EndpointBaseSync
  .WithoutRequest
  .WithResult<List<Category>>
{
    private readonly ICategoryService _categoryService;

    public GetCategories(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ResponseCache(Duration = 60)]
    [EndpointSwaggerOperation(typeof(GetCategories), "Get categories")]
    public override List<Category> Handle()
    {
        return _categoryService.ListCategories();
    }
}