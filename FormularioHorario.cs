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
    public partial class FormularioHorario : Form
    {

        public List<Doctor> Doctors = null;

        public FormularioHorario()
        {
            InitializeComponent();
        }

        private async void FormularioHorario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";

            var doctors = await ConsultasDAL.BuscarMedicosNome();
            this.Doctors = doctors;
            comboBox1.Items.AddRange(doctors.Select(x => x.name).ToArray());
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1 )
            {
                label4.Text = "Selecione um médico";
                return;
            }

            if (dateTimePicker1.Value < DateTime.Now)
            {
                label5.Text = "Não é possível marcar uma consulta no passado";
                return;
            }

            var postTimeSlot = new PostTimeSlot {
                doctorId = Doctors[comboBox1.SelectedIndex].id,
                startTime = dateTimePicker1.Value,
                endTime = dateTimePicker1.Value.AddHours(1)
            };

            var sucesso = await ConsultasDAL.AddTimeSlot(postTimeSlot);
            var mensagem = sucesso ? "Horário adicionado com sucesso." : "Erro ao adicionar horário";
            MessageBox.Show(mensagem);
            this.Close();
        }
    }
}
