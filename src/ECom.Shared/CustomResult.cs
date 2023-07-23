using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ECom.Shared;

public enum CustomResultLevel
{
  None = 0,
  Info,
  Warning,
  Error,
  Critical
}

//public class ValidationError
//{
//  public string? PropertyName { get; init; }
//  public string Message { get; init; }

//  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
//  [System.Text.Json.Serialization.JsonIgnore]
//  public Exception? Exception { get; init; }
//}
public class CustomResult : CustomResult<CustomResult>
{
  public CustomResult<T> ToGenericResult<T>(T data) {
    return new CustomResult<T> {
      Status = Status,
      ErrorCode = ErrorCode,
      Data = data,
      Level = Level,
      Exception = Exception
      //ValidationErrors = this.ValidationErrors
    };
  }
}

public class CustomResult<T>
{
  protected internal CustomResult() {
  }

  public bool Status { get; internal init; }

  public int HttpStatusCode => Status ? 200 : 400;

  public string LevelText => Level switch {
    CustomResultLevel.Info => "info",
    CustomResultLevel.Warning => "warn",
    CustomResultLevel.Error => "error",
    CustomResultLevel.Critical => "critical",
    _ => throw new ArgumentOutOfRangeException()
  };

  //public string Name { get; internal init; }
  public string ErrorCode { get; internal init; }
  public string[] Params { get; internal init; }


  //public ValidationError[] ValidationErrors { get; internal init; }  



  public T? Data { get; internal init; }

  public CustomResultLevel Level { get; internal init; } = CustomResultLevel.None;

  [IgnoreDataMember]
  [JsonIgnore]
  [Newtonsoft.Json.JsonIgnore]
  public Exception? Exception { get; internal init; }


  public (string name, string error) GetErrorAndName() {
    var split = ErrorCode.Split('.');
    var name = split[0];
    var error = split[1];
    return (name, error);
  }

  public static CustomResult<T> Ok(string name, string error, T? data = default) {
    return new CustomResult<T> {
      Status = true,
      ErrorCode = $"{name}.{error}",
      Exception = null,
      Data = data,
      Level = CustomResultLevel.Info
    };
  }

  public static CustomResult<T> Ok(T? data = default) {
    return new CustomResult<T> {
      Status = true,
      ErrorCode = $"{data?.GetType().Name}.Success",
      Data = data,
      Level = CustomResultLevel.Info
    };
  }


  public static CustomResult<T> Warn(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{name}.{error}",
      Level = CustomResultLevel.Warning
    };
  }

  public static CustomResult<T> Error(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{name}.{error}",
      Level = CustomResultLevel.Error
    };
  }

  public static CustomResult<T> Critical(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{name}.{error}",
      Level = CustomResultLevel.Critical
    };
  }

  public static CustomResult<T> Validation(string name, string message) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{name}." + message,
      Level = CustomResultLevel.Warning
    };
  }

  public static CustomResult<T> Critical(Exception? exception, string name) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{name}.Exception",
      Level = CustomResultLevel.Critical,
      Exception = exception
    };
  }


  public CustomResult ToResult() {
    return new CustomResult {
      Status = Status,
      ErrorCode = ErrorCode,
      Level = Level,
      Exception = Exception
      //ValidationErrors = ValidationErrors,
    };
  }


  public static implicit operator CustomResult(CustomResult<T> value) {
    return new CustomResult {
      Status = value.Status,
      ErrorCode = value.ErrorCode,
      Data = null,
      Level = value.Level,
      Exception = value.Exception
      //ValidationErrors = value.ValidationErrors,
    };
  }

  public static implicit operator bool(CustomResult<T> value) {
    return value.Status;
  }

  public static implicit operator CustomResult<T>(CustomResult value) {
    if (value.Status) throw new Exception("Cannot convert success result to generic result");
    return new CustomResult<T> {
      Status = value.Status,
      ErrorCode = value.ErrorCode,
      Level = value.Level,
      Exception = value.Exception
    };
  }

  public static implicit operator CustomResult<T>(T? data) {
    var typeName = data?.GetType().Name ?? "N/A";
    var status = data != null;
    if (status)
      return new CustomResult<T> {
        Status = true,
        ErrorCode = $"{typeName}.Success",
        Data = data,
        Level = CustomResultLevel.Info
      };
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{typeName}.Success",
      Level = CustomResultLevel.Warning
    };
  }
}