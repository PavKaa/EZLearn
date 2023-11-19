using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class Professor
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }

		public virtual IEnumerable<SheduleLessonProfessor> SheduleLessonProfessors { get; set; }
	}
}
