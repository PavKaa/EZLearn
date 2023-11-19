using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class Group
	{
		public string Id { get; set; }
		public string Number { get; set; }

        public string UniversityId { get; set; } //Служебное
		public University University { get; set; }  //Служебное

		public IEnumerable<SheduleTemplate> SheduleTemplates { get; set; } //Служебное
    }
}
