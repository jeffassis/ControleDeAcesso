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
    public partial class FrmUsuarioCadastro : Form
    {
        Usuarios usuario = new Usuarios();
        public FrmUsuarioCadastro(Usuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            // Transferir dados do objeto pra o form
            lblId.Text = usuario.Id.ToString();
            txtEmail.Text = usuario.Email;
            txtNomeCompleto.Text = usuario.Nome;
            txtNomeCurto.Text = usuario.NomeCurto;
            CbAtivo.Text = usuario.Ativo == 'S' ? "Sim" : "Não";
        }
    }
}
