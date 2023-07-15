using Ardalis.ApiEndpoints;
using ECom.Domain.Entities;
using ECom.WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace ECom.WebApi.Endpoints.Option;

[AllowAnonymous]
[EndpointRoute(typeof(GetCategoriesEndpoint))]
public class GetCategoriesEndpoint : EndpointBaseSync
  .WithoutRequest
  .WithResult<List<Category>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesEndpoint(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ResponseCache(Duration = 60)]
    [EndpointSwaggerOperation(typeof(GetCategoriesEndpoint), "Gets valid categories")]
    public override List<Category> Handle()
    {
        return _categoryService.ListCategories();
    }
}