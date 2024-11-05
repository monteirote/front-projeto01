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
    public partial class FormularioMedico : Form
    {
        public FormularioMedico()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var nome = textBox1.Text;
            var especialidade = textBox2.Text;
            var obj = new CreateDoctor { name = nome, specialty = especialidade, profilePicture = "" };

            var sucesso = await ConsultasDAL.CriarMedico(obj);
            var mensagem = sucesso ? "Médico adicionado com sucesso" : "Falha ao adicionar Médico";
            MessageBox.Show(mensagem);
            this.Close();
        }
    }
}
