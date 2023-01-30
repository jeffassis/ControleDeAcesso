using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeAcesso
{
    public class Acessos
    {
        public int IdOpcao { get; set; }
        public string NomeOpcao { get; set; }
        public string DescricaoOpcao { get; set; }
        public int NivelOpcao { get; set; }
        public char Liberado { get; set; }
        public int IdRegistro { get; set; }

        public Acessos() { }

        public Acessos(int idOpcao, string nomeOpcao, string descricaoOpcao, int nivelOpcao, char liberado, int idRegistro)
        {
            IdOpcao = idOpcao;
            NomeOpcao = nomeOpcao;
            DescricaoOpcao = descricaoOpcao;
            NivelOpcao = nivelOpcao;
            Liberado = liberado;
            IdRegistro = idRegistro;
        }

        public Acessos(int idOpcao, char liberado, int idRegistro)
        {
            IdOpcao = idOpcao;
            Liberado = liberado;
            IdRegistro = idRegistro;
        }

        public static List<Acessos> GetMenuAcessos(int id_usuario)
        {
            var sql = @"SELECT o.id, o.nome nomeOpcao, o.descricao descricaoOpcao, o.nivel, 
                            IFNULL(a.liberado, 'N') liberado, IFNULL(a.id_acesso,0) id_acesso 
                        FROM tb_menu_opcoes o 
                        LEFT JOIN (
                            SELECT usuario_id, opcao_id, liberado, id_acesso
                        FROM tb_acesso WHERE usuario_id=@usuario_id) a ON o.id=a.opcao_id";

            var listaAcessos = new List<Acessos>();

            try
            {
                using (var cn = new MySqlConnection(Program.strConn))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@usuario_id", id_usuario);
                        using (var dt = new DataTable())
                        {
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                listaAcessos.Add(new Acessos((int)row["id"], (string)row["nomeOpcao"], (string)row["descricaoOpcao"], (int)row["nivel"], Convert.ToChar(row["liberado"]), 
                                    (int)row["id_acesso"]));
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaAcessos;
        }
    
        public string Salvar(int idUsuario, List<Acessos> listaAcessos)
        {
            try
            {
                using (var cn = new MySqlConnection(Program.strConn))
                {
                    cn.Open();
                    foreach (var item in listaAcessos)
                    {
                        var sql = "";

                        if (item.IdRegistro == 0)
                        {
                            sql = "INSERT INTO tb_acesso(opcao_id, usuario_id, liberado) VALUES(@opcao_id, @usuario_id, @liberado)";
                        }
                        else
                        {
                            sql = "UPDATE tb_acesso SET opcao_id=@opcao_id, usuario_id=@usuario_id, liberado=@liberado WHERE id_acesso=@id";
                        }

                        using (var cmd = new MySqlCommand(sql, cn))
                        {
                            if (item.IdRegistro > 0)
                            {
                                cmd.Parameters.AddWithValue("@id", item.IdRegistro);
                            }
                            cmd.Parameters.AddWithValue("@opcao_id", item.IdOpcao);
                            cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
                            cmd.Parameters.AddWithValue("@liberado", item.Liberado);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
