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
    public partial class FrmUsuarioAcesso : Form
    {
        public FrmUsuarioAcesso(Usuarios usuario)
        {
            InitializeComponent();

            // Transferir os dados do objeto usuario para o form
            lblId.Text = usuario.Id.ToString();
            lblEmail.Text = usuario.Email;
            lblNome.Text = usuario.NomeCurto;

            var listaAcessos = Acessos.GetMenuAcessos(Convert.ToInt32(lblId.Text));

            ConfigurarGrade(listaAcessos);
        }

        private void ConfigurarGrade(List<Acessos> listaAcessos)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            // Id da opcao do menu
            dataGridView1.Columns.Add("opcao_id", "Id");
            dataGridView1.Columns["opcao_id"].Visible = false;

            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns["nome"].Visible = false;

            dataGridView1.Columns.Add("descricao", "Descricao");
            dataGridView1.Columns["descricao"].Width = 347;
            dataGridView1.Columns["descricao"].ReadOnly = true;

            dataGridView1.Columns.Add("nivel", "Nivel");
            dataGridView1.Columns["nivel"].Visible = false;

            // Id do registro do acesso
            dataGridView1.Columns.Add("id_acesso", "Id do Acesso");
            dataGridView1.Columns["id_acesso"].Visible = false;

            dataGridView1.Columns.Add("usuario_id", "Usuario");
            dataGridView1.Columns["usuario_id"].Visible = false;

            // situacao corrente
            dataGridView1.Columns.Add("liberado", "Liberado");
            dataGridView1.Columns["liberado"].Visible = false;

            // adicionar uma coluna checkbox
            var acesso = new DataGridViewCheckBoxColumn();
            acesso.Name = "acesso";
            acesso.HeaderText = "Liberar";
            acesso.Width = 50;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);

            try
            {
                foreach (var item in listaAcessos)
                {
                    dataGridView1.Rows.Add(item.IdOpcao, item.NivelOpcao, item.DescricaoOpcao, item.NivelOpcao, item.IdRegistro, 
                                            Convert.ToInt32(lblId.Text), item.Liberado, item.Liberado == 'S' ? true : false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var listaAcessos = new List<Acessos>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var chk = Convert.ToBoolean(row.Cells["acesso"].Value) ? 'S' : 'N';

                if (Convert.ToChar(row.Cells["liberado"].Value) != chk)
                {
                    listaAcessos.Add(new Acessos(Convert.ToInt32(row.Cells["opcao_id"].Value), chk, Convert.ToInt32(row.Cells["id_acesso"].Value)));
                }
            }

            var id_usuario = Convert.ToInt32(lblId.Text);
            if (listaAcessos.Count > 0)
            {
                if (new Acessos().Salvar(id_usuario, listaAcessos) == "ok")
                {
                    MessageBox.Show("Acessos salvos!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possivel salvar!\nTente novamente ou tente mais tarde!");
                }
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Serve para não buga a ultima selecao do DGV
            dataGridView1.EndEdit();
        }
    }
}
