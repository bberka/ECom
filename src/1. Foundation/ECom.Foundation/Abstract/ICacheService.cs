namespace ECom.Foundation.Abstract;

public interface ICacheService<T> where T : class
{
  void ClearCache();
  void SetCacheValue(T data);
  T? GetFromCache();
  T GetFromDb();
}