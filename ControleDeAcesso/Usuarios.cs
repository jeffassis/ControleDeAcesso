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

        public string Salvar(Usuarios usuario)
        {
            var sql = "";

            if (usuario.Id == 0)
            {
                sql = "INSERT INTO tb_usuario (email, nome, nome_curto, ativo) VALUES (@email, @nome, @nome_curto, @ativo)";
            }
            else
            {
                sql = "UPDATE tb_usuario SET email=@email, nome=@nome, nome_curto=@nome_curto, ativo=@ativo WHERE id_usuario=@id";
            }

            try
            {
                using (var cn = new MySqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        if (usuario.Id > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", usuario.Id);
                        }
                        cmd.Parameters.AddWithValue("email", usuario.Email);
                        cmd.Parameters.AddWithValue("nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("nome_curto", usuario.NomeCurto);
                        cmd.Parameters.AddWithValue("ativo", usuario.Ativo);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {                
                return ex.Message;
            }

        }

        public bool Excluir(int id)
        {
            var sql = "DELETE FROM tb_usuario WHERE id_usuario=@id";

            try
            {
                using (var cn = new MySqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
