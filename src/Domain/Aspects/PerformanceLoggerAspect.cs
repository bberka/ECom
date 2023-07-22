using System.Diagnostics;
using AspectInjector.Broker;
using Serilog;

namespace ECom.Domain.Aspects;

[Aspect(Scope.PerInstance)]
[Injection(typeof(PerformanceLoggerAspect))]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class PerformanceLoggerAspect : Attribute 
{
  public PerformanceLoggerAspect() {
    _logThresholdMilliseconds = 1000;
  }

  public PerformanceLoggerAspect(int logThresholdMilliseconds) {
    _logThresholdMilliseconds = logThresholdMilliseconds;
  }
  private readonly int _logThresholdMilliseconds;

  [Advice(Kind.Around)] // you can have also After (async-aware), and Around(Wrap/Instead) kinds
  public object Intercept(
    [Argument(Source.Target)] Func<object[], object> target,
    [Argument(Source.Arguments)] object[] args,
    //[Argument(Source.Instance)] object instance,
    [Argument(Source.Name)] string methodName,
    [Argument(Source.Type)] Type type,
    [Argument(Source.ReturnType)] Type returnType) {
    var className = type.Name;
    var argList = string.Join(",", args);
    var sw = Stopwatch.StartNew();
    try {
      var result = target(args);
      return result;
    } finally {
      sw.Stop();
      if (_logThresholdMilliseconds < sw.ElapsedMilliseconds) {
        Log.Warning("{className}.{methodName}({argList}) Action too long to execute, executed in {ElapsedMilliseconds} ms", className, methodName, argList, sw.ElapsedMilliseconds);
      }
    }
  }
}


//public CustomResult<T> Intercept<T>(Func<CustomResult<T>> method) {
//  try {
//    return method();
//  } catch (Exception ex) {
//    Log.Error(ex, "Interceptor exception");
//    return DomainResult.Exception(ex, "Interceptor exception");
//  }
//}
//public CustomResult Intercept(Func<CustomResult> method) {
//  try {
//    return method();
//  } catch (Exception ex) {
//    Log.Error(ex, "Interceptor exception");
//    return DomainResult.Exception(ex, "Interceptor exception");
//  }
//}