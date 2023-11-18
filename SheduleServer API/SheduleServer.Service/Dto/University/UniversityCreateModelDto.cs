using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.University
{
	public class UniversityCreateModelDto
	{
		[Required(ErrorMessage = "Required field")]
		[MaxLength(50, ErrorMessage = "Max length of field is 50 symbols")]
		[MinLength(5, ErrorMessage = "Min length of field is 5 symbols")]
		public string Title { get; set; }
	}
}
