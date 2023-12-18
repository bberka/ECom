using ECom.Foundation.Enum;
using ECom.Foundation.Models;

namespace ECom.Foundation;

public class Result : Result<Result>
{
  public Result<T> ToGenericResult<T>(T data) {
    return new Result<T> {
      Status = Status,
      Errors = Errors,
      Data = data,
      Level = Level,
      Exception = Exception
    };
  }
}

public readonly struct Error
{
  public string Code { get; }
  public LocParam[] LocParams { get; }

  public Error(string code, LocParam[] locParams) {
    Code = code;
    LocParams = locParams;
  }
}

public class Result<T>
{
  protected internal Result() { }
  public bool Status { get; internal init; }

  public ResultLevel Level { get; internal init; }

  public string LevelText => Level switch {
    ResultLevel.Info => "info",
    ResultLevel.Warning => "warn",
    ResultLevel.Error => "error",
    ResultLevel.Fatal => "fatal",
    _ => throw new ArgumentOutOfRangeException()
  };

  public List<Error> Errors { get; internal init; }

  // public string ErrorCode { get; internal init; }
  // public LocParam[] RequestData { get; internal init; } = Array.Empty<LocParam>();
  public T? Data { get; internal init; }

  [IgnoreDataMember]
  [System.Text.Json.Serialization.JsonIgnore]
  [JsonIgnore]
  public Exception? Exception { get; internal init; }


  public static Result<T> Ok(string error, T? data = default, params LocParam[] locParams) {
    return new Result<T> {
      Status = true,
      Errors = new List<Error> { new(error, locParams) },
      Exception = null,
      Data = data,
      Level = ResultLevel.Info
    };
  }

  public static Result<T> OkData(T data, params LocParam[] locParams) {
    return new Result<T> {
      Status = true,
      Errors = new List<Error> { new("success", locParams) },
      Data = data,
      Level = ResultLevel.Info
    };
  }

  public static Result<T> OkParam(string error, params LocParam[] locParams) {
    return new Result<T> {
      Status = true,
      Errors = new List<Error> { new(error, locParams) },
      Exception = null,
      Data = default,
      Level = ResultLevel.Info
    };
  }

  public static Result<T> Warn(string error, params LocParam[] locParams) {
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new(error, locParams) },
      Level = ResultLevel.Warning
    };
  }

  public static Result<T> Error(string error, params LocParam[] locParams) {
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new(error, locParams) },
      Level = ResultLevel.Error
    };
  }

  public static Result<T> Fatal(string error, params LocParam[] locParams) {
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new(error, locParams) },
      Level = ResultLevel.Fatal
    };
  }

  public static Result<T> Validation(string message, params LocParam[] locParams) {
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new(message, locParams) },
      Level = ResultLevel.Warning
    };
  }

  public static Result<T> Validation(List<Error> errors) {
    return new Result<T> {
      Status = false,
      Errors = errors,
      Level = ResultLevel.Warning
    };
  }

  public static Result<T> Fatal(Exception? exception, params LocParam[] locParams) {
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new("fatal", locParams) },
      Level = ResultLevel.Fatal,
      Exception = exception
    };
  }


  public Result ToResult() {
    return new Result {
      Status = Status,
      Errors = Errors,
      Level = Level,
      Exception = Exception,
      Data = null
    };
  }


  public static implicit operator Result(Result<T> value) {
    return new Result {
      Status = value.Status,
      Errors = value.Errors,
      Data = null,
      Level = value.Level,
      Exception = value.Exception
    };
  }

  public static implicit operator bool(Result<T> value) {
    return value.Status;
  }

  public static implicit operator Result<T>(Result value) {
    if (value.Status) throw new Exception("Cannot convert success result to generic result");
    return new Result<T> {
      Status = value.Status,
      Errors = value.Errors,
      Level = value.Level,
      Exception = value.Exception
    };
  }

  public static implicit operator Result<T>(T? data) {
    var typeName = data?.GetType().Name ?? "N/A";
    var status = data != null;
    if (status)
      return new Result<T> {
        Status = true,
        Errors = new List<Error> { new("success", Array.Empty<LocParam>()) },
        Data = data,
        Level = ResultLevel.Info
      };
    return new Result<T> {
      Status = false,
      Errors = new List<Error> { new("not_found", new[] { new LocParam("name", typeName) }) },
      Level = ResultLevel.Warning
    };
  }
}