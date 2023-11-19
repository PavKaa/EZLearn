namespace SheduleServer_API.Models.SheduleLesson
{
	public class SheduleLessonCreatingModel
	{
		public string Id { get; set; }
		public string Type { get; set; }

		public string LessonId { get; set; }

		public string LessonTimeId { get; set; }
	}
}
