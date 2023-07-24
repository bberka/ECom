using AspectInjector.Broker;
using EasMe;

namespace ECom.Domain.Aspects;

/// <summary>
/// Basic caching aspect for caching method results.
/// Cache key is built from namespace, class name, method name and arguments.
/// It uses EasMemoryCache singleton class.
/// </summary>
[Aspect(Scope.Global)]
[Injection(typeof(CacheAspect))]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class CacheAspect : Attribute
{
  public int DurationSeconds { get; set; } = 1;
  public bool VaryByArguments { get; set; } = true;

  [Advice(Kind.Around)]
  public object Intercept(
    [Argument(Source.Target)] Func<object[], object> target,
    [Argument(Source.Arguments)] object[] args,
    [Argument(Source.Name)] string methodName,
    [Argument(Source.Type)] Type type,
    [Argument(Source.ReturnType)] Type returnType) {
    var cacheKey = BuildCacheKey(type, methodName, args, VaryByArguments);
    var cacheResult = EasMemoryCache.This.Get(cacheKey);
    if (cacheResult is not null) return cacheResult;
    var result = target(args);
    EasMemoryCache.This.Set(cacheKey,result, DurationSeconds);
    return result;
  }

  private static string BuildCacheKey(Type classType, string methodName, object[] args, bool varyByArguments) {
    var nameSpace = classType.Namespace;
    var classTypeName = classType.Name;
    var cacheKey = $"{nameSpace}.{classTypeName}.{methodName}";
    if (!varyByArguments) return cacheKey;
    if (args.Length == 0) return cacheKey;
    var array = args.Select(x => x.GetHashCode()).ToList();
    var joined = string.Join(", ", array);
    cacheKey += $".{joined}";
    return cacheKey;
  }
}