using System.Text.Json.Serialization;

namespace ECom.Domain.ValueObjects
{
	public class Result
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		internal Result() {}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		[JsonIgnore]
		public ushort Rv { get; set; }
		public bool IsSuccess { get => Rv == 0; }
		public string ErrorCode { get; set; } = Constants.ErrCode.None.ToString();
		public string[] Parameters { get; set; }
		public static Result Success(ErrCode err = ErrCode.Success, params string[] parameters) => new() { Rv = 0, ErrorCode = err.ToString(), Parameters = parameters };
		public static Result Success(params string[] parameters) => new() { Rv = 0,  ErrorCode = ErrCode.Success.ToString() ,Parameters = parameters };
		public static Result Error(ushort rv, ErrCode err = ErrCode.Error) => new() { Rv = rv, ErrorCode = err.ToString() };
		public static Result Error(ushort rv, ErrCode err, params string[] parameters) => new() { Rv = rv, ErrorCode = err.ToString(), Parameters = parameters };
		public static Result Error(ushort rv, string err, params string[] parameters) => new() { Rv = rv, ErrorCode = err, Parameters = parameters };
	
		public static string GetErrorCodeAndParams(string errorCodeDataWithParams, out string[] parameters)
		{
			parameters = new string[1];
			var split = errorCodeDataWithParams.Split(':');
			if (split.Length == 0) return errorCodeDataWithParams;
			for (int i = 1; i < split.Length; i++)
			{
				var item = split[i];
				_ = parameters.Append(item);
			}
			return errorCodeDataWithParams;
		}
	}
}
