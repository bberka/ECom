using System.Globalization;
using System.Resources;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ECom.Shared.Extensions;
using ECom.Shared.Resources;
using Microsoft.Extensions.Localization;

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
      Exception = Exception,
      Params = Params
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
  public LocParam[] Params { get; internal init; } = Array.Empty<LocParam>();


  //public ValidationError[] ValidationErrors { get; internal init; }  



  public T? Data { get; internal init; }

  public CustomResultLevel Level { get; internal init; } = CustomResultLevel.None;

  [IgnoreDataMember]
  [System.Text.Json.Serialization.JsonIgnore]
  [Newtonsoft.Json.JsonIgnore]
  public Exception? Exception { get; internal init; }

  /// <summary>
  /// Gets localized message for current culture that result is created
  /// </summary>
  public string Message {
    get {
      _message ??= GetFormattedMessage();
      return _message;
    }
  }
  private string? _message;

  private string GetFormattedMessage() {
    var currentCulture = CultureInfo.CurrentCulture;
    var resourceManager = new ResourceManager(typeof(LocalizedResource));
    var localizedErrorCode = resourceManager.GetString(ErrorCode, currentCulture);
    if (localizedErrorCode == null)
      return ErrorCode;
    string result = localizedErrorCode;
    foreach (var param in Params) result = result.LocFormat(param.Key, param.Value);
    return result;
  }
  public string GetFormattedMessage(LocalizedString localizedErrorCode) {
    LocalizedString result = localizedErrorCode;
    foreach (var param in Params) result = result.Format(param.Key, param.Value);
    return result;
  }
  public static CustomResult<T> Ok(string error, T? data = default,params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = true,
      ErrorCode =error,
      Exception = null,
      Data = data,
      Level = CustomResultLevel.Info,
      Params = paramStrings
    };
  }

  public static CustomResult<T> OkData(T data,params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = true,
      ErrorCode = $"success",
      Data = data,
      Level = CustomResultLevel.Info,
      Params = paramStrings
    };
  }
  public static CustomResult<T> OkParam(string error,params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = true,
      ErrorCode =error,
      Exception = null,
      Data = default,
      Level = CustomResultLevel.Info,
      Params = paramStrings
    };
  }
  public static CustomResult<T> Warn(string error, params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = error,
      Level = CustomResultLevel.Warning,
      Params = paramStrings
    };
  }

  public static CustomResult<T> Error( string error,params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = error,
      Level = CustomResultLevel.Error,
      Params =  paramStrings
    };
  }

  public static CustomResult<T> Critical( string error, params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = error,
      Level = CustomResultLevel.Critical,
      Params = paramStrings
    };
  }

  public static CustomResult<T> Validation(string message, params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode =  message,
      Level = CustomResultLevel.Warning,
      Params = paramStrings
    };
  }

  public static CustomResult<T> Critical(Exception? exception,  params LocParam[] paramStrings) {
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"Exception",
      Level = CustomResultLevel.Critical,
      Exception = exception,
      Params = paramStrings
    };
  }


  public CustomResult ToResult() {
    return new CustomResult {
      Status = Status,
      ErrorCode = ErrorCode,
      Level = Level,
      Exception = Exception,
      Params = Params,
      //ValidationErrors = ValidationErrors,
    };
  }


  public static implicit operator CustomResult(CustomResult<T> value) {
    return new CustomResult {
      Status = value.Status,
      ErrorCode = value.ErrorCode,
      Data = null,
      Level = value.Level,
      Exception = value.Exception,
      Params = value.Params
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
      Exception = value.Exception,
      Params = value.Params
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
        Level = CustomResultLevel.Info,
      };
    return new CustomResult<T> {
      Status = false,
      ErrorCode = $"{typeName}.Success",
      Level = CustomResultLevel.Warning
    };
  }
}