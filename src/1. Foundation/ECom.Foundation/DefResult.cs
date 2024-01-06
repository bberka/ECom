// using ECom.Foundation.Models;
// using ECom.Foundation.Static;
//
// namespace ECom.Foundation;
//
// /// <summary>
// ///   Defined Results
// /// </summary>
// public static class DefResult
// {
//   public static Result exception(ExceptionInfo exception,
//                                  string name,
//                                  ResultLevel level = ResultLevel.Fatal) {
//     var errorList = ErrorListBuilder
//                     .New("exception", "name", name)
//                     .Build();
//     return new Result(false, level, errorList, exception);
//   }
//
//   public static Result validation_error(FieldError error,
//                                         string name) {
//     var errorList = ErrorListBuilder
//                     .New(error.ToString(), "name", name)
//                     .Build();
//     return new Result(false, ResultLevel.Warning, errorList);
//   }
//   
//   public static Result action_ok(ActionSuccess success,
//                                  string name) {
//     var errorList = ErrorListBuilder
//                     .New(success.ToString(), "name", name)
//                     .Build();
//     return new Result(true, ResultLevel.Info, errorList);
//   }
//   
//
//   public static Result unauthorized_x(string name) { 
//     var errorList = ErrorListBuilder
//                     .New("unauthorized_x", "name", name)
//                     .Build();
//     return new Result(false, ResultLevel.Error, errorList);
//   }
//
//   public static Result forbidden(string name) {
//     var errorList = ErrorListBuilder
//                     .New("forbidden", "name", name)
//                     .Build();
//     return new Result(false, ResultLevel.Error, errorList);
//   }
//
//   public static Result under_maintenance() { 
//     var errorList = ErrorListBuilder
//                     .New("under_maintenance")
//                     .Build();
//     return new Result(false, ResultLevel.Warning, errorList);
//   }
//
//   public static Result db_internal_error(string operationName) {
//      var errorList = ErrorListBuilder
//                     .New("db_internal_error", "operationName", operationName)
//                     .Build();
//     return new Result(false, ResultLevel.Fatal, errorList);
//   }
//
//   
//   
//   private class ErrorListBuilder
//   {
//     private ErrorListBuilder() {
//       _errors = new();
//     }
//
//     private List<ResultMessage> _errors;
//
//     public List<ResultMessage> Build() {
//       return _errors;
//     }
//
//     public ErrorListBuilder Add(string message,
//                                 Dictionary<string, object> parameters) {
//       _errors.Add(new ResultMessage(message, parameters));
//       return this;
//     }  
//     public ErrorListBuilder Add(string message) {
//       _errors.Add(new ResultMessage(message, new Dictionary<string, object>()));
//       return this;
//     }
//
//     public ErrorListBuilder AddSingleParam(string message,
//                                            string key,
//                                            object value) {
//       _errors.Add(new ResultMessage(message, new Dictionary<string, object> { { key, value } })); 
//       return this;
//     }
//
//   
//     public static ErrorListBuilder New(string message,
//                                        string key,
//                                        object value) {
//       return new ErrorListBuilder().AddSingleParam(message, key, value);
//     }  
//     public static ErrorListBuilder New(string message) {
//       return new ErrorListBuilder().Add(message);
//     }
//   
//   }
// }

