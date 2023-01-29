using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcesso
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string NomeCurto { get; set; }
        public char Ativo { get; set; }

        public Usuarios() { }

        public Usuarios(int id, string email, string nome, string nomeCurto, char ativo)
        {
            Id = id;
            Email = email;
            Nome = nome;
            NomeCurto = nomeCurto;
            Ativo = ativo;
        }

        public static DataTable BuscarTodos()
        {
            var sql = "SELECT id_usuario, email, nome, nome_curto, ativo FROM tb_usuario";

            var dt = new DataTable();

            try
            {
                using (var cn = new MySqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}
