using AspectInjector.Broker;
using Serilog;

namespace ECom.Domain.Aspects;

[Aspect(Scope.PerInstance)]
[Injection(typeof(ExceptionHandlerAspect))]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class ExceptionHandlerAspect : Attribute
{
  private static readonly Type CustomResultGenericType = typeof(CustomResult<>);
  private static readonly Type CustomResultType = typeof(CustomResult);

  [Advice(Kind.Around)]
  public object Intercept(
    [Argument(Source.Target)] Func<object[], object> target,
    [Argument(Source.Arguments)] object[] args,
    //[Argument(Source.Instance)] object instance,
    [Argument(Source.Name)] string methodName,
    [Argument(Source.Type)] Type type,
    [Argument(Source.ReturnType)] Type returnType) {
    var className = type.Name;
    var argList = string.Join(",", args);
    object result;
    try {
      result = target(args);
    }
    catch (Exception ex) {
      var msg = $"Exception in {className}.{methodName}({argList})";
      Log.Fatal(ex, msg);
      var isCustomResultType = IsCustomResultType(returnType);
      if (!isCustomResultType) throw new Exception(msg, ex);
      result = DomainResult.Exception(ex, methodName);
    } 
    return result;
  }
  private static bool IsCustomResultType(Type type) {
    if (!type.IsGenericType) return type == CustomResultType;
    var genericType = type.GetGenericTypeDefinition();
    return genericType == CustomResultGenericType;
  }
}