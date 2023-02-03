using EasMe.Extensions;
using System.Text.Json.Serialization;

namespace ECom.Domain.ValueObjects
{
	public class ResultData<T>
	{
		private ResultData() { }

		[JsonIgnore]
		public ushort Rv { get; set; } = ushort.MaxValue;
		public bool IsSuccess { get => Rv == 0; }
		public string ErrorCode { get; set; } = Constants.ErrCode.None.ToString();
		public T? Data { get; set; }
		public string[] Parameters { get; set; }
		public static ResultData<T> Success(T data) 
			=> new() { Rv = 0, ErrorCode = Constants.ErrCode.Success.ToString(), Data = data };
		public static ResultData<T> Success(T data, ErrCode err) 
			=> new() { Rv = 0, ErrorCode = err.ToString(),Data = data };
		public static ResultData<T> Success(T data, ErrCode err, params string[] parameters) 
			=> new() { Rv = 0, ErrorCode = err.ToString(), Parameters = parameters,Data =data, };
		public static ResultData<T> Error(ushort rv, ErrCode res) => new() { Rv = rv, ErrorCode = res.ToString() };
		public static ResultData<T> Error(ushort rv, string res) => new() { Rv = rv, ErrorCode = res };
		public static ResultData<T> Error(ushort rv, ErrCode res, params string[] parameters) => new() { Rv = rv, ErrorCode = res.ToString(), Parameters = parameters };
		public static ResultData<T> Error(ushort rv, string res, params string[] parameters) => new() { Rv = rv, ErrorCode = res, Parameters = parameters };

	}
}
