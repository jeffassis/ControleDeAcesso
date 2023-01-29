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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var opcoes = Opcoes.Criar(menuStrip1);

            dataGridView1.DataSource = opcoes.ToList();

            ConfigurarGrade();

            Opcoes.SalvarMenu(opcoes);
        }

        private void ConfigurarGrade()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["nome"].HeaderText = "Nome";
            dataGridView1.Columns["nome"].Width = 300;
            dataGridView1.Columns["nome"].ReadOnly = true;

            dataGridView1.Columns["descricao"].HeaderText = "Descricao";
            dataGridView1.Columns["descricao"].Width = 380;
            dataGridView1.Columns["descricao"].ReadOnly = true;

            dataGridView1.Columns["nivel"].HeaderText = "Nivel";
            dataGridView1.Columns["nivel"].Width = 60;
            dataGridView1.Columns["nivel"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["nivel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["nivel"].ReadOnly = true;

            // Adicionar a coluna cheked
            var acesso = new DataGridViewCheckBoxColumn();
            acesso.HeaderText = "Libearado";
            acesso.Width = 68;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);
        }
    }
}
