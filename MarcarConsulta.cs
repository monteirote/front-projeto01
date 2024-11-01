using FrontClinicaMedica.DALs;
using FrontClinicaMedica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontClinicaMedica
{
    public partial class MarcarConsulta : Form
    {
        public List<TimeSlot> TimeSlots = new List<TimeSlot>();

        public MarcarConsulta ()
        {
            InitializeComponent();
        }

        private void MarcarConsulta_Load(object sender, EventArgs e)
        {
            var doctors = ConsultasDAL.BuscarMedicos();
        }
    }
}
