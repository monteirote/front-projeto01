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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            var token = await UsuarioDAL.FazerLogin(new Models.UsuarioLogin { Email = email, Password = senha });

            UsuarioInfo.JWTToken = token;

            var marcarConsulta = new MarcarConsulta();
            marcarConsulta.Show();
            this.Hide();
        }
    }
}
