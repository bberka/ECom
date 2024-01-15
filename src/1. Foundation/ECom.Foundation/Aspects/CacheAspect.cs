using System.Reflection;
using AspectInjector.Broker;
using EasMe;
using ECom.Foundation.Static;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ECom.Foundation.Aspects;

/// <summary>
///   Basic caching aspect for caching method results.
///   Cache key is built from namespace, class name, method name and arguments.
///   It uses EasMemoryCache singleton class.
/// </summary>
[Aspect(Scope.Global)]
[Injection(typeof(CacheAspect))]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class CacheAspect : Attribute
{
  [FromServices]
  public IMemoryCache MemoryCache { get; set; }


  [Advice(Kind.Around)]
  public object Intercept(
    [Argument(Source.Target)] Func<object[], object> target,
    [Argument(Source.Arguments)] object[] args,
    [Argument(Source.Name)] string methodName,
    [Argument(Source.Type)] Type type,
    [Argument(Source.ReturnType)] Type returnType) {
    var cacheKey = BuildCacheKey(type, methodName, args);
    var cacheResult = EasMemoryCache.This.Get(cacheKey);
    if (cacheResult is not null) return cacheResult;
    var result = target(args);
    EasMemoryCache.This.Set(cacheKey, result, 1);
    return result;
  }

  private static string BuildCacheKey(Type classType, string methodName, object[] args) {
    var nameSpace = classType.Namespace;
    var classTypeName = classType.Name;
    var cacheKey = $"{nameSpace}.{classTypeName}.{methodName}";
    if (args.Length == 0) return cacheKey;
    var array = args.Select(x => x.GetHashCode()).ToList();
    var joined = string.Join(", ", array);
    cacheKey += $".{joined}";
    return cacheKey;
  }
}