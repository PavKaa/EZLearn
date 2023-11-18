using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.LessonTime
{
	public class LessonTimeUpdateModelDto
	{
        public int Id { get; set; }

		public int Order { get; set; }

		public string TimeStart { get; set; }

		public string TimeEnd { get; set; }
	}
}
