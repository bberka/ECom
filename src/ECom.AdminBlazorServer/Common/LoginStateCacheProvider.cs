using System.Collections.Concurrent;

namespace ECom.AdminBlazorServer.Common;

public class LoginStateCacheProvider
{
  //used as singleton
  private readonly ConcurrentBag<string> _tokens = new();

  public void Add(string token) {
    if (token == null) throw new ArgumentNullException(nameof(token));
    if(_tokens.Contains(token)) return;
    _tokens.Add(token);
  }

  public bool Validate(string token) {
    return _tokens.Contains(token);
  }

  public void Remove(string token) {
    var exist = _tokens.Contains(token);
    if (!exist) return;
    _tokens.TryTake(out _);
  }

}