using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SheduleServer.Service.Instruments
{
	public static class RandomIdGenerator
	{
		public static string GenerateRandomId() 
		{
			string allowedCharsPattern = "[A-Za-z0-9]";
			var random = new Random();
			var id = new string(Enumerable.Repeat(allowedCharsPattern, 16)
			  .Select(s => Regex.Match(s, allowedCharsPattern).Value[random.Next(s.Length)]).ToArray());
			return id;
		}
	}
}
