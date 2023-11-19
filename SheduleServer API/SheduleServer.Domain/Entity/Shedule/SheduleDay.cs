﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class SheduleDay
	{
        public string Id { get; set; }
        public DayType DayType { get; set; }
		public Parity Parity { get; set; }

		public string SheduleTemplateId { get; set; }
        public SheduleTemplate SheduleTemplate { get; set; }

		public virtual IEnumerable<SheduleLessonsInDay> SheduleLessonsInDays { get; set; }
	}

    public enum DayType
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY
    }

    public enum Parity
    {
        EVEN,
        ODD
    }
}
