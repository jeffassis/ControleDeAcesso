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
        public FrmUsuarioCadastro(Usuarios usuario, Operacao operacao)
        {
            InitializeComponent();
            this.usuario = usuario;

            if (operacao == Operacao.Adicionar && usuario.Id == 0)
            {
                this.Text += " - Adicionar";
            }
            else if (operacao == Operacao.Editar)
            {
                this.Text += " - Editar";
            }
            else if (operacao == Operacao.Remover)
            {
                this.Text += " - Remover";
                TravarControles();
                BtnSalvar.Visible = false;
                BtnOk.Visible = true;
                BtnOk.Text = "Excluir";
            }
            else if (operacao == Operacao.Consultar)
            {
                this.Text += " - Consultar";
                TravarControles();
                BtnSalvar.Visible = false;
                BtnOk.Visible = true;
                BtnOk.Text = "Fechar";
            }           

            // Transferir dados do objeto pra o form
            lblId.Text = usuario.Id.ToString();
            txtEmail.Text = usuario.Email;
            txtNomeCompleto.Text = usuario.Nome;
            txtNomeCurto.Text = usuario.NomeCurto;
            CbAtivo.Text = usuario.Ativo == 'S' ? "Sim" : "Não";
        }

        private void TravarControles()
        {
            txtEmail.Enabled = false;
            txtNomeCompleto.Enabled = false;
            txtNomeCurto.Enabled = false;
            CbAtivo.Enabled = false;
        }

        private void FrmUsuarioCadastro_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            // transferir dados do form para o objeto
            usuario.Id = Convert.ToInt32(lblId.Text);
            usuario.Email = txtEmail.Text;
            usuario.Nome = txtNomeCompleto.Text;
            usuario.NomeCurto = txtNomeCurto.Text;
            usuario.Ativo = CbAtivo.Text[0];

            var result = usuario.Salvar(usuario);

            if (result == "ok")
            {
                MessageBox.Show("Salvo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possivel salvar, tente novamente.\n" + result);
                usuario.Id = -1;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (BtnOk.Text == "Fechar")
            {
                this.Close();
            }
            else
            {
                var resposta = MessageBox.Show("Deseja excluir?", "Excluir", MessageBoxButtons.YesNo, 
                                                                            MessageBoxIcon.Question, 
                                                                            MessageBoxDefaultButton.Button2);

                if (resposta == DialogResult.Yes)
                {
                    var result = usuario.Excluir(usuario.Id);
                    if (result)
                    {
                        MessageBox.Show("Excluido");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel excluir, tente novamente.");
                        usuario.Id = -1;
                    }
                }
            }
        }
    }
}
