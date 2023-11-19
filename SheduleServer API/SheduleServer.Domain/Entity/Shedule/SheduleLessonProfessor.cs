using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class SheduleLessonProfessor
	{
		public string Id { get; set; }

        public string SheduleLessonId { get; set; }
        public SheduleLesson SheduleLesson { get; set; }

        public string ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
