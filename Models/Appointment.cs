using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontClinicaMedica.Models
{
    class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; } = new Doctor();
        public User Patient { get; set; } = new User();
        public DateTime CreatedAt { get; set; }
        public TimeSlot TimeSlot { get; set; } = new TimeSlot();
        public string Notes { get; set; } = string.Empty;
    }

    public class PostAppointment
    {
        public int DoctorId { get; set; }

        public int TimeSlotId { get; set; }

        public string PatientEmail { get; set; }

        public string Notes { get; set; } = string.Empty;
    }


    public class GetAppointment
    {
        public int id { get; set; }
        public DoctorTimeSlot doctor { get; set; } = new DoctorTimeSlot();
        public User patient { get; set; } = new User();
        public DateTime createdAt { get; set; }
        public SimpleTimeSlotViewModel timeSlot { get; set; } = new SimpleTimeSlotViewModel();
        public string notes { get; set; } = string.Empty;
    }


    public class GetAppointmentByEmail
    {
        public int id { get; set; }
        public GetTSDoctor doctor { get; set; }
        public User patient { get; set; } = new User();
        public DateTime createdAt { get; set; }
        public SimpleTimeSlotViewModel timeSlot { get; set; } = new SimpleTimeSlotViewModel();
        public string notes { get; set; } = string.Empty;
    }
}
