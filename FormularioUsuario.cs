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
    public partial class FormularioUsuario : Form
    {
        public FormularioUsuario()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var nome = textBox2.Text;
            var email = textBox1.Text;
            var senha = textBox3.Text;

            if (nome == "" || email == "" || senha == "")
            {
                label5.Text = "Preencha todos os campos";
                return;
            }

            var sucesso = await UsuarioDAL.CriarUsuario(new Models.UsuarioSignup { name = nome, email = email, password = senha });
            var mensagem = sucesso ? "Usuário adicionado com sucesso" : "Falha ao adicionar usuário";
            MessageBox.Show(mensagem);
            this.Close();
        }
    }
}
