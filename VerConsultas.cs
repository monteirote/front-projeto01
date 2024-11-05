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
    public partial class VerConsultas : Form
    {
        public static List<GetAppointment> consultas = new List<GetAppointment>();
        public static GetAppointment ConsultaSelecionadaAtualmente = null;
        public VerConsultas()
        {
            InitializeComponent();
        }

        private async void VerConsultas_Load(object sender, EventArgs e)
        {
            ConsultaSelecionadaAtualmente = null;
            consultas = await ConsultasDAL.BuscarAppointmentsPorUser();
            foreach (var h in consultas)
            {
                comboBox1.Items.Add(h.doctor.name + " || " + h.timeSlot.startTime.ToString("g") + " até " + h.timeSlot.endTime.ToString("t"));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (comboBox1.SelectedIndex == -1) {
                label5.Text = "Selecione uma consulta.";
                return;
            }

            var consultaSelecionada = consultas[comboBox1.SelectedIndex];
            textBox2.Text = consultaSelecionada.doctor.name;
            textBox4.Text = consultaSelecionada.doctor.specialty;
            textBox3.Text = consultaSelecionada.createdAt.ToString("G");
            textBox1.Text = consultaSelecionada.notes;

            ConsultaSelecionadaAtualmente = consultaSelecionada;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            if (ConsultaSelecionadaAtualmente == null)
            {
                label7.Text = "Selecione uma consulta primeiro.";
                return;
            }

            var idToDelete = ConsultaSelecionadaAtualmente.id;

            var sucesso = await ConsultasDAL.DeletarAppointment(idToDelete);
            var mensagem = sucesso ? "Consulta desmarcada com sucesso" : "Falha em desmarcar a consulta";
            MessageBox.Show(mensagem);
            this.Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (ConsultaSelecionadaAtualmente == null)
            {
                label6.Text = "Selecione uma consulta primeiro.";
                return;
            }

            var sucesso = await ConsultasDAL.EditarAppointment(ConsultaSelecionadaAtualmente.id, textBox1.Text);

            var mensagem = sucesso ? "Consulta editada com sucesso" : "Falha em editar a consulta";
            MessageBox.Show(mensagem);
            this.Close();
        }
    }
}
