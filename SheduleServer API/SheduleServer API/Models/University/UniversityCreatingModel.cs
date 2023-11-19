using System.ComponentModel.DataAnnotations;

namespace SheduleServer_API.Models.University
{
	public class UniversityCreatingModel
	{
		[Required(ErrorMessage = "Required field")]
		[MaxLength(50, ErrorMessage = "Max length of field is 50 symbols")]
		[MinLength(5, ErrorMessage = "Min length of field is 5 symbols")]
		public string Title { get; set; }
	}
}
