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
    public partial class FrmUsuarios : Form
    {
        Usuarios usuario = new Usuarios();
        public FrmUsuarios()
        {
            InitializeComponent();
            dataGridView1.DataSource = Usuarios.BuscarTodos();

            ConfigurarGrade();
        }

        private void ConfigurarGrade()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            //dataGridView1.Columns["id_usuario"].Visible = false;

            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["email"].Width = 250;
            dataGridView1.Columns["email"].ReadOnly = true;

            dataGridView1.Columns["nome"].HeaderText = "Nome";
            dataGridView1.Columns["nome"].Width = 310;
            dataGridView1.Columns["nome"].ReadOnly = true;

            dataGridView1.Columns["nome_curto"].HeaderText = "Nome Curto";
            dataGridView1.Columns["nome_curto"].Width = 150;
            dataGridView1.Columns["nome_curto"].ReadOnly = true;

            dataGridView1.Columns["ativo"].HeaderText = "Ativo";
            dataGridView1.Columns["ativo"].Width = 60;
            dataGridView1.Columns["ativo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ativo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ativo"].ReadOnly = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                TransferirGradeParaUsuario();
                
                using (var form = new FrmUsuarioCadastro(usuario, Operacao.Editar))
                {
                    form.ShowDialog();

                    if (usuario.Id != -1)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id_usuario"].Value = usuario.Id;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["email"].Value = usuario.Email;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome"].Value = usuario.Nome;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome_curto"].Value = usuario.NomeCurto;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ativo"].Value = usuario.Ativo;
                    }
                }
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            ReiniciarUsuario(usuario);

            using (var form = new FrmUsuarioCadastro(usuario, Operacao.Adicionar))
            {
                form.ShowDialog();

                dataGridView1.DataSource = Usuarios.BuscarTodos();
            }
        }

        private void ReiniciarUsuario(Usuarios usuario)
        {
            usuario.Id = 0;
            usuario.Email = "";
            usuario.Nome = "";
            usuario.NomeCurto = "";
            usuario.Ativo = 'S';
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                TransferirGradeParaUsuario();

                using (var form = new FrmUsuarioCadastro(usuario, Operacao.Remover))
                {
                    form.ShowDialog();

                    if (usuario.Id != -1)
                    {
                        dataGridView1.DataSource = Usuarios.BuscarTodos();
                    }
                }
            }
        }

        private void TransferirGradeParaUsuario()
        {
            // tranfereindo os dados do DGV para objeto usuario
            usuario.Id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id_usuario"].Value);
            usuario.Email = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["email"].Value.ToString();
            usuario.Nome = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome"].Value.ToString();
            usuario.NomeCurto = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["nome_curto"].Value.ToString();
            usuario.Ativo = Convert.ToChar(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ativo"].Value);

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                TransferirGradeParaUsuario();

                using (var form = new FrmUsuarioCadastro(usuario, Operacao.Consultar))
                {
                    form.ShowDialog();

                    if (usuario.Id != -1)
                    {
                        dataGridView1.DataSource = Usuarios.BuscarTodos();
                    }
                }
            }
        }
    }
}
