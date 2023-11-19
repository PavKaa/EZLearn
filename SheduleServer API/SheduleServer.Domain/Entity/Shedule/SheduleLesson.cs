using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class SheduleLesson
	{
        public string Id { get; set; }
        public LessonType Type { get; set; }

        public string LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public string LessonTimeId { get; set; }
        public LessonTime LessonTime { get; set; }

        public virtual IEnumerable<SheduleLessonsInDay> SheduleLessonsInDays { get; set; }
    }

    public enum LessonType
    {
        LECTURE,
        SEMINAR,
        LABORATORY_WORK,
        COURSE_WORK
    }
}
