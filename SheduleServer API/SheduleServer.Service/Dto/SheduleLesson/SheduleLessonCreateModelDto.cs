using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.SheduleLesson
{
	public class SheduleLessonCreateModelDto
	{
        public int Type { get; set; }

        public int LessonId { get; set; }

        public int LessonTimeId { get; set; }

    }
}
