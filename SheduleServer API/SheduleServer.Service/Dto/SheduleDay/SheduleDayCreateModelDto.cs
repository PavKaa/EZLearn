using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Dto.SheduleDay
{
	public class SheduleDayCreateModelDto
	{
        public int DayType { get; set; }

        public bool Parity { get; set; }

        public int SheduleTemplateId { get; set; }
    }
}
