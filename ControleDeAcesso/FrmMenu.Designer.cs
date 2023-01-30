
namespace ControleDeAcesso
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroVendedores = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFaturamento = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturamentoEmitirNota = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturamentoCancelarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturamentoConsultarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturamentoConsultaDoMes = new System.Windows.Forms.ToolStripMenuItem();
            this.FaturamentoComissaoVendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.AcessoCadastroUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.AcessoControleAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.ControleAcessoInativarAtivar = new System.Windows.Forms.ToolStripMenuItem();
            this.ControleAcessoAcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastro,
            this.menuFaturamento,
            this.menuAcesso,
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCadastro
            // 
            this.menuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroClientes,
            this.CadastroVendedores,
            this.CadastroFornecedores});
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(69, 20);
            this.menuCadastro.Text = "Cadastro ";
            // 
            // CadastroClientes
            // 
            this.CadastroClientes.Name = "CadastroClientes";
            this.CadastroClientes.Size = new System.Drawing.Size(145, 22);
            this.CadastroClientes.Text = "Clientes";
            // 
            // CadastroVendedores
            // 
            this.CadastroVendedores.Name = "CadastroVendedores";
            this.CadastroVendedores.Size = new System.Drawing.Size(145, 22);
            this.CadastroVendedores.Text = "Vendedores";
            // 
            // CadastroFornecedores
            // 
            this.CadastroFornecedores.Name = "CadastroFornecedores";
            this.CadastroFornecedores.Size = new System.Drawing.Size(145, 22);
            this.CadastroFornecedores.Text = "Fornecedores";
            // 
            // menuFaturamento
            // 
            this.menuFaturamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaturamentoEmitirNota,
            this.FaturamentoCancelarNota,
            this.FaturamentoConsultarNota,
            this.FaturamentoConsultaDoMes,
            this.FaturamentoComissaoVendedor});
            this.menuFaturamento.Name = "menuFaturamento";
            this.menuFaturamento.Size = new System.Drawing.Size(87, 20);
            this.menuFaturamento.Text = "Faturamento";
            // 
            // FaturamentoEmitirNota
            // 
            this.FaturamentoEmitirNota.Name = "FaturamentoEmitirNota";
            this.FaturamentoEmitirNota.Size = new System.Drawing.Size(238, 22);
            this.FaturamentoEmitirNota.Text = "Emitir Nota Fiscal";
            // 
            // FaturamentoCancelarNota
            // 
            this.FaturamentoCancelarNota.Name = "FaturamentoCancelarNota";
            this.FaturamentoCancelarNota.Size = new System.Drawing.Size(238, 22);
            this.FaturamentoCancelarNota.Text = "Cancelar Nota Fiscal";
            // 
            // FaturamentoConsultarNota
            // 
            this.FaturamentoConsultarNota.Name = "FaturamentoConsultarNota";
            this.FaturamentoConsultarNota.Size = new System.Drawing.Size(238, 22);
            this.FaturamentoConsultarNota.Text = "Consultar Nota Fiscal";
            // 
            // FaturamentoConsultaDoMes
            // 
            this.FaturamentoConsultaDoMes.Name = "FaturamentoConsultaDoMes";
            this.FaturamentoConsultaDoMes.Size = new System.Drawing.Size(238, 22);
            this.FaturamentoConsultaDoMes.Text = "Consultar Faturamento do Mês";
            // 
            // FaturamentoComissaoVendedor
            // 
            this.FaturamentoComissaoVendedor.Name = "FaturamentoComissaoVendedor";
            this.FaturamentoComissaoVendedor.Size = new System.Drawing.Size(238, 22);
            this.FaturamentoComissaoVendedor.Text = "Comissão de Vendedores";
            // 
            // menuAcesso
            // 
            this.menuAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AcessoCadastroUsuario,
            this.AcessoControleAcesso});
            this.menuAcesso.Name = "menuAcesso";
            this.menuAcesso.Size = new System.Drawing.Size(56, 20);
            this.menuAcesso.Text = "Acesso";
            // 
            // AcessoCadastroUsuario
            // 
            this.AcessoCadastroUsuario.Name = "AcessoCadastroUsuario";
            this.AcessoCadastroUsuario.Size = new System.Drawing.Size(180, 22);
            this.AcessoCadastroUsuario.Text = "Cadastro de Usuário";
            this.AcessoCadastroUsuario.Click += new System.EventHandler(this.AcessoCadastroUsuario_Click);
            // 
            // AcessoControleAcesso
            // 
            this.AcessoControleAcesso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ControleAcessoInativarAtivar,
            this.ControleAcessoAcesso});
            this.AcessoControleAcesso.Name = "AcessoControleAcesso";
            this.AcessoControleAcesso.Size = new System.Drawing.Size(180, 22);
            this.AcessoControleAcesso.Text = "Controle de Acesso";
            // 
            // ControleAcessoInativarAtivar
            // 
            this.ControleAcessoInativarAtivar.Name = "ControleAcessoInativarAtivar";
            this.ControleAcessoInativarAtivar.Size = new System.Drawing.Size(180, 22);
            this.ControleAcessoInativarAtivar.Text = "Inativar e Ativar";
            // 
            // ControleAcessoAcesso
            // 
            this.ControleAcessoAcesso.Name = "ControleAcessoAcesso";
            this.ControleAcessoAcesso.Size = new System.Drawing.Size(180, 22);
            this.ControleAcessoAcesso.Text = "Acesso";
            this.ControleAcessoAcesso.Click += new System.EventHandler(this.ControleAcessoAcesso_Click);
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(38, 20);
            this.menuSair.Text = "Sair";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 289);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuFaturamento;
        private System.Windows.Forms.ToolStripMenuItem menuAcesso;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem CadastroClientes;
        private System.Windows.Forms.ToolStripMenuItem CadastroVendedores;
        private System.Windows.Forms.ToolStripMenuItem CadastroFornecedores;
        private System.Windows.Forms.ToolStripMenuItem FaturamentoEmitirNota;
        private System.Windows.Forms.ToolStripMenuItem FaturamentoCancelarNota;
        private System.Windows.Forms.ToolStripMenuItem FaturamentoConsultarNota;
        private System.Windows.Forms.ToolStripMenuItem FaturamentoConsultaDoMes;
        private System.Windows.Forms.ToolStripMenuItem FaturamentoComissaoVendedor;
        private System.Windows.Forms.ToolStripMenuItem AcessoCadastroUsuario;
        private System.Windows.Forms.ToolStripMenuItem AcessoControleAcesso;
        private System.Windows.Forms.ToolStripMenuItem ControleAcessoInativarAtivar;
        private System.Windows.Forms.ToolStripMenuItem ControleAcessoAcesso;
    }
}

