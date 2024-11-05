using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontClinicaMedica.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class GetTimeSlot
    {
        public int id { get; set; }
        public DoctorTimeSlot doctor { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isAvailable { get; set; }
    }

    public class SimpleTimeSlotViewModel
    {
        public int id { get; set; }
        public DateTime startTime { get; set; } = new DateTime();
        public DateTime endTime { get; set; } = new DateTime();
        public bool isAvailable { get; set; } = false;
    }
}
