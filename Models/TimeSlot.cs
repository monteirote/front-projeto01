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
}
