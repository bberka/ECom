using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
	public class Result
	{
		public ushort Rv { get; set; }
		public bool IsSuccess { get => Rv == 0; }
		public string Message { get; set; }
		public static Result Success() => new() { Rv = 0, Message = "Success" };
		public static Result Success(string message) => new() { Rv = 0, Message = message };
		public static Result Error(ushort rv, string message) => new() { Rv = rv, Message = message };
		public static Result Error(string message) => new() { Rv = ushort.MaxValue, Message = message };
	}
}
