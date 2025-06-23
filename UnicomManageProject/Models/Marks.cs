using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManageProject.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public string Exam { get; set; }
        public string Score { get; set; }
    }
}
