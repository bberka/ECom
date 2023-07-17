namespace ECom.Application.SetupMiddleware;

[AttributeUsage(AttributeTargets.Method)]
public class InitializeOrderAttribute : Attribute
{
  public InitializeOrderAttribute(int order) {
    Order = order;
  }
  public int Order { get; }  
}