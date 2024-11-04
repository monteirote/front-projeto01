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
    public partial class HorariosDisponiveis : Form
    {
        public BuscaInfo infos = null;
        public List<GetTimeSlot> horariosDisponiveis = null;

        public HorariosDisponiveis (BuscaInfo info)
        {
            this.infos = info;
            InitializeComponent();
        }

        private async void HorariosDisponiveis_Load(object sender, EventArgs e)
        {
            var horariosEncontrados = await ConsultasDAL.BuscarTimeSlotsDisponiveis(this.infos);

            horariosEncontrados = horariosEncontrados.OrderBy(x => x.startTime).ToList();

            this.horariosDisponiveis = horariosEncontrados;

            var items = (from h in horariosDisponiveis
                         select h.doctor.name + " || das " + h.startTime.ToString("g") + " até " + h.endTime.ToString("t")).ToArray();

            comboBox1.Items.AddRange(items);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";

            if (comboBox1.SelectedIndex == -1)
            {
                label2.Text = "Escolha um horário";
                return;
            }

            var horarioSelecionado = this.horariosDisponiveis[comboBox1.SelectedIndex];

            var info = new PostAppointment {
                DoctorId = horarioSelecionado.doctor.id,
                TimeSlotId = horarioSelecionado.id,
                PatientEmail = UsuarioInfo.Email,
                Notes = textBox1.Text
            };

            var sucesso = await ConsultasDAL.MarcarConsulta(info);
            var mensagem = sucesso ? "Consulta marcada com sucesso" : "Não foi possível marcar sua consulta";

            MessageBox.Show(mensagem);

            this.Hide();
            new MarcarConsulta().Show();
        }
    }
}
