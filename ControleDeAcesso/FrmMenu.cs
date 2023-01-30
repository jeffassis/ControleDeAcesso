using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcesso
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

       

        private void AcessoCadastroUsuario_Click(object sender, EventArgs e)
        {
            using (var form = new FrmUsuarios())
            {
                form.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ControleAcessoAcesso_Click(object sender, EventArgs e)
        {
            using (var form = new FrmUsuarios("selecionar"))
            {
                form.ShowDialog();
            }
        }
    }
}
