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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            var token = await UsuarioDAL.FazerLogin(new UsuarioLogin { Email = email, Password = senha });

            UsuarioInfo.SetToken(token);


            if (UsuarioInfo.Role == "Admin")
            {
                var formPergunta = new PerguntaVersao();
                formPergunta.Show();
                this.Hide();
                return;
            }

            var marcarConsulta = new MarcarConsulta();
            marcarConsulta.Show();
            this.Hide();
        }
    }
}
