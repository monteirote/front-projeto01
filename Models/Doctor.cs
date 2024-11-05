using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontClinicaMedica.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string specialty { get; set; } = string.Empty;
        public string profilePicture { get; set; } = string.Empty;
        public List<TimeSlot> availability { get; set; } = new List<TimeSlot>();
    }

    public class DoctorTimeSlot
    {
        public int id { get; set; }
        public string name { get; set; }
        public string specialty { get; set; }
    }

    public class CreateDoctor
    {
        public string name { get; set; }
        public string specialty { get; set; }
        public string profilePicture { get; set; }  
    }

}
