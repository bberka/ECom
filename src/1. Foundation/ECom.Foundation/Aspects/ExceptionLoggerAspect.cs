using AspectInjector.Broker;
using Serilog;

namespace ECom.Foundation.Aspects;

/// <summary>
///   Basic exception logger aspect for logging exceptions and rethrowing them with a more descriptive message.
/// </summary>
[Aspect(Scope.PerInstance)]
[Injection(typeof(ExceptionLoggerAspect))]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class ExceptionLoggerAspect : Attribute
{
  [Advice(Kind.Around)]
  public object Intercept(
    [Argument(Source.Target)] Func<object[], object> target,
    [Argument(Source.Arguments)] object[] args,
    [Argument(Source.Name)] string methodName,
    [Argument(Source.Type)] Type type,
    [Argument(Source.ReturnType)] Type returnType) {
    var className = type.Name;
    var argList = string.Join(",", args);
    try {
      return target(args);
    }
    catch (Exception ex) {
      var msg = $"Exception in {className}.{methodName}({argList}) Message:{ex.Message}";
      Log.Fatal(ex, msg);
      throw new Exception(msg, ex);
    }
  }
}