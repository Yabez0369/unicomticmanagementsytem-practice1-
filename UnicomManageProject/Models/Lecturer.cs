using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManageProject.Models
{
    internal class Lecturer
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public string Password { get; set; }         
        public string Address { get; set; }
        public string Phone { get; set; }          
        public string Course { get; set; }
        public string Subject { get; set; }
    }
}
