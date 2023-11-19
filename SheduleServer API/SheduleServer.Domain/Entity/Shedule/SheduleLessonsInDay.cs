using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class SheduleLessonsInDay
	{
        public string Id { get; set; }

        public string SheduleDayId { get; set; }
        public SheduleDay SheduleDay { get; set; }

		public string SheduleLessonId { get; set; }
		public SheduleLesson SheduleLesson { get; set; }
	}
}
