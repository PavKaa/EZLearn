using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.SheduleLesson
{
	public class SheduleLessonCreateModelDto
	{
        public string Type { get; set; }

        public string LessonId { get; set; }

        public string LessonTimeId { get; set; }

    }
}
