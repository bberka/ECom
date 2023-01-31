namespace ECom.Domain.ValueObjects
{
	public class ResultData<T>
	{
		private ResultData() { }
		public ushort Rv { get; set; } = ushort.MaxValue;
		public bool IsSuccess { get => Rv == 0; }
		public Response Response { get; set; }
		public T? Data { get; set; }
		public static ResultData<T> Success(T data) => new() { Rv = 0, Data = data, Response = Response.Success };
		public static ResultData<T> Success(T data,Response res) => new() { Rv = 0, Data = data, Response = res };
		public static ResultData<T> Error(ushort rv, Response res) => new() { Rv = rv, Response = res };
	}
}
