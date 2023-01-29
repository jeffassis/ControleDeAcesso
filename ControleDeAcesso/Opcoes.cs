using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcesso
{
    public class Opcoes
    {
        private const string strConn = "SERVER=localhost; DATABASE=project_acesso; UID=root; PWD=; PORT=;";

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Nivel { get; set; }

        public Opcoes(string nome, string descricao, int nivel)
        {
            Nome = nome;
            Descricao = descricao;
            Nivel = nivel;
        }

        public static HashSet<Opcoes> Criar(MenuStrip menu)
        {
            var hashSetOpcoes = new HashSet<Opcoes>();

            // Nivel 1
            foreach (ToolStripMenuItem item in menu.Items)
            {
                var descricao1 = item.Text;

                if (item.HasDropDownItems)
                {
                    // Nivel 2
                    foreach (ToolStripMenuItem opcao in item.DropDownItems)
                    {
                        var descricao2 = descricao1 + " / " + opcao.Text;

                        if (opcao.HasDropDownItems)
                        {
                            // Nivel 3
                            foreach (ToolStripMenuItem subOpcao in opcao.DropDownItems)
                            {
                                var descricao3 = descricao2 + " / " + subOpcao.Text;
                                hashSetOpcoes.Add(new Opcoes(subOpcao.Name, descricao3, 3));
                            }
                        }
                        else
                        {
                            hashSetOpcoes.Add(new Opcoes(opcao.Name, descricao2, 2));
                        }
                    }
                }
                else
                {
                    hashSetOpcoes.Add(new Opcoes(item.Name, descricao1, 1));
                }
            }
            return hashSetOpcoes;
        }

        public static bool SalvarMenu(HashSet<Opcoes> opcoes)
        {
            var sql = "INSERT INTO tb_menu_opcoes(nome, descricao, nivel) VALUES(@nome, @descricao, @nivel)";

            try
            {
                using (var cn = new MySqlConnection(strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@descricao", MySqlDbType.VarChar);
                        cmd.Parameters.Add("@nivel", MySqlDbType.Int32);

                        foreach (var item in opcoes)
                        {
                            cmd.Parameters["@nome"].Value = item.Nome;
                            cmd.Parameters["@descricao"].Value = item.Descricao;
                            cmd.Parameters["@nivel"].Value = item.Nivel;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
