using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManageProject.Models
{
    internal class Timetable
    {
        public int TimetableId { get; set; }
        public string Room { get;set; }
        public string Timeslot { get;set; }
        public string Subject { get; set; }
    }
}
