namespace ECom.Domain.ValueObjects
{
	public class Result
	{
		private Result()
		{

		}
		public ushort Rv { get; set; }
		public bool IsSuccess { get => Rv == 0; }
		public Response Response { get; set; } = Response.None;
		public string ResponseAsString { get => Response.ToString();  }
		public int ResponseAsInt { get => (int)Response;  }
		public static Result Success() => new() { Rv = 0, Response = Response.Success };
		public static Result Success(Response res) => new() { Rv = 0, Response = res };
		public static Result Error(ushort rv, Response res) => new() { Rv = rv, Response = res };
	}
}
