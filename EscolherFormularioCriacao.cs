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
    public partial class EscolherFormularioCriacao : Form
    {
        public EscolherFormularioCriacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormularioUsuario().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FormularioMedico().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormularioHorario().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new PerguntaVersao().Show();
        }
    }
}
