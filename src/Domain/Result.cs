﻿using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog.Events;

namespace ECom.Domain;
public enum CustomResultLevel
{
  Auto,
  Info,
  Warning,
  Error,
  Critical
}

public class ValidationError
{
  public string? PropertyName { get; init; }
  public string Message { get; init; }

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  [System.Text.Json.Serialization.JsonIgnore]
  public Exception? Exception { get; init; }
}
public class CustomResult : CustomResult<CustomResult>
{
  public CustomResult<T> ToGenericResult<T>(T data) {
    return new CustomResult<T> {
      Status = this.Status,
      Message = this.Message,
      Data = data,
      Level = this.Level,
      Exception = this.Exception,
      TranslatedMessage = this.TranslatedMessage,
      ValidationErrors = this.ValidationErrors
    };
  }
  public new ActionResult<CustomResult> ToActionResult() {
    if (Status) {
      return new OkObjectResult(this);
    }
    return new BadRequestObjectResult(this);
  }
  public new ActionResult<CustomResult> ToActionResult(int failStatusCode) {
    if (Status) {
      return new OkObjectResult(this);
    }
    return new ObjectResult(this) {
      StatusCode = failStatusCode
    };
  }


}
public class CustomResult<T>
{
  protected internal CustomResult() {
    if (CustomResultLevel.Auto == Level) {
      Level = Status ? CustomResultLevel.Info : CustomResultLevel.Error;
    }

  }

  public bool Status { get; internal init; } = false;
  public OperationMessage Message { get; internal init; }
  public ValidationError[] ValidationErrors { get; internal init; }  

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public string? TranslatedMessage { get; internal init; }
  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public T? Data { get; internal init; }
  public CustomResultLevel Level { get; internal init; } = CustomResultLevel.Auto;

  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  [System.Text.Json.Serialization.JsonIgnore]
  //[Newtonsoft.Json.JsonIgnore]
  public Exception? Exception { get; internal init; }

  public static CustomResult<T> Ok(string name, string error, T? data = default) {
    return new CustomResult<T> {
      Status = true,
      Message = OperationMessage.Create(name, error),
      Exception = null,
      Data = data
    };
  }
  public static CustomResult<T> Ok(T? data = default) {
    return new CustomResult<T> {
      Status = true,
      Message = OperationMessage.Create(data?.GetType().Name ?? "N/A", "Success"),
      Data = data,
      Level = CustomResultLevel.Info
    };
  }

  public static CustomResult<T> ValidationError(string name, ValidationError[] errors) {
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(name, "ValidationError"),
      Level = CustomResultLevel.Warning,
      ValidationErrors = errors
    };
  }
  public static CustomResult<T> Warn(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(name, error),
      Level = CustomResultLevel.Warning,
    };
  }
  public static CustomResult<T> Error(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(name, error),
      Level = CustomResultLevel.Error,
    };
  }

  public static CustomResult<T> Critical(string name, string error) {
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(name, error),
      Level = CustomResultLevel.Critical,
    };
  }

  public static CustomResult<T> Critical(Exception? exception, string name) {
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(name, "Exception"),
      Level = CustomResultLevel.Critical,
      Exception = exception
    };
  }

  public static CustomResult<T> WithTranslation(LanguageType? language = null) {
    if (language is null) {
      var context = new HttpContextAccessor().HttpContext;
      language = context.Request.GetLanguageType();
    }
    throw new NotImplementedException();
  }

  public virtual ActionResult<CustomResult<T>> ToActionResult() {
    if (Status) {
      return new OkObjectResult(this);
    }
    return new BadRequestObjectResult(this);
  }
  public virtual ActionResult<CustomResult<T>> ToActionResult(int failStatusCode ) {
    if (Status) {
      return new OkObjectResult(this);
    }
    return new ObjectResult(this) {
      StatusCode = failStatusCode
    };
  }

  public CustomResult ToResult(){
    return new CustomResult {
      Status = Status,
      Message = Message,
      Level = Level,
      Exception = Exception,
      ValidationErrors = ValidationErrors,
      TranslatedMessage = TranslatedMessage
    };
  }


  public static implicit operator CustomResult(CustomResult<T> value) {
    return new CustomResult {
      Status = value.Status,
      Message = value.Message,
      Data = null,
      Level = value.Level,
      Exception = value.Exception,
      ValidationErrors = value.ValidationErrors,
      TranslatedMessage = value.TranslatedMessage

    };
  }

  public static implicit operator bool(CustomResult<T> value) {
    return value.Status;
  }
  public static implicit operator CustomResult<T>(CustomResult value) {
    if(value.Status) throw new Exception("Cannot convert success result to generic result");
    return new CustomResult<T> {
      Status = value.Status,
      Message = value.Message,
      Level = value.Level,
      Exception = value.Exception,
      ValidationErrors = value.ValidationErrors,
      TranslatedMessage = value.TranslatedMessage
    };
  }
  public static implicit operator CustomResult<T>(T? data) {
    var typeName = data?.GetType().Name ?? "N/A";
    var status = data != null;
    if (status) {
      return new CustomResult<T> {
        Status = true,
        Message = OperationMessage.Create(typeName, "Success"),
        Data = data,
        Level = CustomResultLevel.Info
      };
    }
    return new CustomResult<T> {
      Status = false,
      Message = OperationMessage.Create(typeName, "NotFound"),
      Level = CustomResultLevel.Warning,
    };
  }
}