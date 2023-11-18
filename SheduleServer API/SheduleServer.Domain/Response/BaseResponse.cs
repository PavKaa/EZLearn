﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Response
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }
		public int StatusCode { get; set; }
		public T Data { get; set; }
	}

	public interface IBaseResponse<T>
	{
		public string Description { get; set; }
		public int StatusCode { get; set; }
		public T Data { get; set; }
	}
}
