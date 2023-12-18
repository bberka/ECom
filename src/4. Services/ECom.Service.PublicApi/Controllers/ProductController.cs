namespace ECom.Service.PublicApi.Controllers;

[AllowAnonymous]
public class ProductController : PublicControllerBase
{
  [FromServices]
  public IProductService ProductService { get; set; }


  [Endpoint("/product/list", HttpMethodType.POST)]
  public List<Product> List(Request_PageWithCulture request) {
    return ProductService.GetProducts(request.Page, request.Culture);
  }
}