﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Domain.Entity.Shedule
{
	public class University
	{
        public string Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Group> Groups { get; set; }
    }
}
