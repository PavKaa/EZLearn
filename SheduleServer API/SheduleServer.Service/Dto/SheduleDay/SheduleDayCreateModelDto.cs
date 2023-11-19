using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.SheduleDay
{
	public class SheduleDayCreateModelDto
	{
        public string DayType { get; set; }

        public string Parity { get; set; }

        public string SheduleTemplateId { get; set; }
    }
}
