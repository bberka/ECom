using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
	public class ResultData<T>
	{
		public ushort Rv { get; set; } 
		public bool IsSuccess { get => Rv == 0; }
		public string Message { get; set; }
		public T? Data { get; set; }
		public static ResultData<T> Success(T data) => new() { Rv = 0, Data = data, Message = "Success" };
		public static ResultData<T> Success(T data,string message) => new() { Rv = 0, Data = data, Message = message };
		public static ResultData<T> Error(ushort rv, string message) => new() { Rv = rv, Message = message };
		public static ResultData<T> Error(string message) => new() { Rv = ushort.MaxValue, Message = message };
	}
}
