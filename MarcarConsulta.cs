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
        public List<Doctor> Doctors = null;

        public MarcarConsulta ()
        {
            InitializeComponent();
        }

        private async void MarcarConsulta_Load(object sender, EventArgs e)
        {
            var doctors = await ConsultasDAL.BuscarMedicosNome();
            this.Doctors = doctors;
            comboBox1.Items.AddRange(doctors.Select(x => x.name).ToArray());

            var especialidades = await ConsultasDAL.BuscarMedicosEspecialidade();
            comboBox2.Items.AddRange(especialidades.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string nomeDoutor = (string) comboBox1.SelectedItem;
            var doutorSelecionado = this.Doctors.Where(x => x.name == nomeDoutor).FirstOrDefault();

            if (doutorSelecionado == null || comboBox1.SelectedIndex == -1) {
                label5.Text = "Selecione algum médico antes de continuar.";
                return;
            }

            var info = new BuscaInfo { Tipo = "nome", Value = doutorSelecionado.id.ToString() };

            this.Hide();
            new HorariosDisponiveis(info).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            var especialidade = (string) comboBox2.SelectedItem;

            if (especialidade == null || comboBox2.SelectedIndex == -1)
            {
                label6.Text = "Selecione alguma especialidade antes de continuar.";
                return;
            }

            var info = new BuscaInfo { Tipo = "especialidade", Value = especialidade };

            this.Hide();
            new HorariosDisponiveis(info).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new VerConsultas().ShowDialog();
        }
    }
}
