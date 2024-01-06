using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Serialization;
using ECom.Foundation.Lib;
using ECom.Foundation.Models;
using ECom.Foundation.Static;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace ECom.Foundation;

public class Result : Result<object>
{
  internal Result(bool status,
                  ResultLevel level,
                  List<ResultMessage> errors,
                  Exception? exception = null) : base(status, level, errors, exception, new object()) { }

  [Newtonsoft.Json.JsonIgnore]
  [System.Text.Json.Serialization.JsonIgnore]
  [IgnoreDataMember]
  public override object Value => null;

  public static implicit operator bool(Result value) {
    return value.Status;
  }

  public static implicit operator Result(bool value) {
    return new Result(value, ResultLevel.Info, new List<ResultMessage>());
  }


  public static implicit operator Result(Exception value) {
    return new Result(false, ResultLevel.Fatal, new List<ResultMessage>(), value);
  }

  public static implicit operator Result(List<ResultMessage> value) {
    return new Result(false, ResultLevel.Warning, value);
  }

  public static implicit operator Result(ResultMessage value) {
    return new Result(false, ResultLevel.Warning, new List<ResultMessage> { value });
  }


  public static Result operator &(Result a,
                                  Result b) {
    if (a.Status && b.Status) return true;
    if (!a.Status && !b.Status) return a._errors.Concat(b._errors).ToList();
    return a.Status
             ? b._errors
             : a._errors;
  }

  public static Result operator |(Result a,
                                  Result b) {
    if (a.Status || b.Status) return true;
    return a._errors.Concat(b._errors).ToList();
  }

  public static Result operator !(Result a) {
    return !a.Status;
  }


  internal static Result Success(ServerMessage message) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString())
                      });
  }

  //FOR performance
  internal static Result Success(ServerMessage message,
                                 object param1) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1
                            })
                      });
  }

  internal static Result Success(ServerMessage message,
                                 object param1,
                                 object param2) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2
                            })
                      });
  }

  internal static Result Success(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3
                            })
                      });
  }

  internal static Result Success(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3,
                                 object param4) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4
                            })
                      });
  }

  internal static Result Success(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3,
                                 object param4,
                                 object param5) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4, param5
                            })
                      });
  }

  internal static Result Success(ServerMessage message,
                                 params string[] prm) {
    return new Result(true,
                      ResultLevel.Info,
                      new List<ResultMessage>() {
                        new(message.ToString(), prm)
                      });
  }

  internal static Result Success(List<ResultMessage> list) {
    return new Result(true, ResultLevel.Info, list);
  }

  internal static Result Warning(ServerMessage loc) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(loc.ToString())
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 params object[] parameters) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(), parameters)
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 object param1) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1
                            })
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 object param1,
                                 object param2) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2
                            })
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3
                            })
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3,
                                 object param4) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4
                            })
                      });
  }

  internal static Result Warning(ServerMessage message,
                                 object param1,
                                 object param2,
                                 object param3,
                                 object param4,
                                 object param5) {
    return new Result(false,
                      ResultLevel.Warning,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4, param5
                            })
                      });
  }


  internal static Result Warning(List<ResultMessage> list) {
    return new Result(false, ResultLevel.Warning, list);
  }

  internal static Result Error(ServerMessage message) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString())
                      });
  }

  internal static Result Error(ServerMessage message,
                               params object[] parameters) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(), parameters)
                      });
  }

  internal static Result Error(ServerMessage message,
                               object param1) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1
                            })
                      });
  }

  internal static Result Error(ServerMessage message,
                               object param1,
                               object param2) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2
                            })
                      });
  }

  internal static Result Error(ServerMessage message,
                               object param1,
                               object param2,
                               object param3) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3
                            })
                      });
  }

  internal static Result Error(ServerMessage message,
                               object param1,
                               object param2,
                               object param3,
                               object param4) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4
                            })
                      });
  }

  internal static Result Error(ServerMessage message,
                               object param1,
                               object param2,
                               object param3,
                               object param4,
                               object param5) {
    return new Result(false,
                      ResultLevel.Error,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4, param5
                            })
                      });
  }


  internal static Result Error(List<ResultMessage> list) {
    return new Result(false, ResultLevel.Error, list);
  }


  internal static Result Fatal(ServerMessage message) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString())
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               params object[] parameters) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(), parameters)
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               object param1) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1
                            })
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               object param1,
                               object param2) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2
                            })
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               object param1,
                               object param2,
                               object param3) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3
                            })
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               object param1,
                               object param2,
                               object param3,
                               object param4) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4
                            })
                      });
  }

  internal static Result Fatal(ServerMessage message,
                               object param1,
                               object param2,
                               object param3,
                               object param4,
                               object param5) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new(message.ToString(),
                            new[] {
                              param1, param2, param3, param4, param5
                            })
                      });
  }

  internal static Result Fatal(List<ResultMessage> list) {
    return new Result(false, ResultLevel.Fatal, list);
  }

  internal static Result Exception(Exception ex,
                                   string name = "",
                                   ResultLevel level = ResultLevel.Fatal) {
    return new Result(false,
                      ResultLevel.Fatal,
                      new List<ResultMessage>() {
                        new("exception", new[] { name })
                      },
                      ex);
  }
}

public class Result<T>
{
  protected readonly List<ResultMessage> _errors;

  private readonly Exception? _exceptionInfo;

  protected string _message = string.Empty;

  internal Result(bool status,
                  ResultLevel level,
                  List<ResultMessage> errors,
                  Exception? exception = null,
                  object? value = null) {
    if (errors == null) throw new ArgumentNullException(nameof(errors));
    if (errors.Count == 0) throw new ArgumentException("Error list cannot be an empty collection.", nameof(errors));
    Status = status;
    Level = level;
    _errors = errors;
    _exceptionInfo = exception;
    if (value is not null)
      Value = (T)value;
  }

  public string Message {
    get {
      if (!string.IsNullOrEmpty(_message)) return _message;
      if (_errors.Count == 0) return string.Empty;
      var sb = new StringBuilder();
      foreach (var error in _errors) {
        if (error.Parameters != null && error.Parameters.Length > 0) {
          var translated = CultureLib.This.GetWithParams(error.Key, error.Parameters);
          sb.AppendLine(translated);
        }
        else {
          var translated = CultureLib.This.Get(error.Key);
          sb.AppendLine(translated);
        }
      }

      return sb.ToString();
    }
  }

  public bool Status { get; }

  [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
  public ResultLevel Level { get; }

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public virtual T Value { get; } = default;

  public Exception? GetException() {
    return _exceptionInfo;
  }

  public T GetValue<T>() {
    if (Value is null)
      throw new Exception($"Cannot convert null to {typeof(T).Name}");
    if (Value is not T value)
      throw new Exception($"Cannot convert {Value?.GetType().Name} to {typeof(T).Name}");
    return value;
  }


  public static implicit operator bool(Result<T> value) {
    return value.Status;
  }

  public static implicit operator Result<T>(Result result) {
    return new Result<T>(result.Status, result.Level, result._errors, result._exceptionInfo, result.Value);
  }

  public static implicit operator T(Result<T> result) {
    return result.GetValue<T>();
  }

  public static implicit operator Result<T>(T value) {
    if (value is null) throw new ArgumentNullException(nameof(value), "Cannot convert null to Result<T>");
    return new Result<T>(true, ResultLevel.Info, new List<ResultMessage>(), null, value);
  }


  public Result ToResult() {
    return new(Status, Level, _errors, _exceptionInfo);
  }
}

public readonly struct ResultMessage
{
  public string Key { get; }
  public object[] Parameters { get; } = null;

  public ResultMessage(string key,
                       object[] parameters) {
    Key = key;
    Parameters = parameters;
  }

  public ResultMessage(string key) {
    Key = key;
  }
}