using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjetoAcessoUsuario
{
    static class Control
    {
        static SqlConnection conex = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#\2018-2\BancoDados.mdf;Integrated Security=True;Connect Timeout=30");
        static private DataTable table;

        //static public bool SelectLogin(string login, string password)
        //{
        //    SqlCommand checkLogin = new SqlCommand();
        //    checkLogin.Connection = conex;
        //    checkLogin.Parameters.AddWithValue("@login", login);
        //    checkLogin.Parameters.AddWithValue("@passwd", password);

        //    checkLogin.CommandText = "SELECT login from usuario WHERE login = @login AND senha = @passwd";
        //    conex.Open();
        //    string x = (string) checkLogin.ExecuteScalar();
        //    conex.Close();

        //    if (x == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        static public DataTable SelectUsers()
        {
            DataTable table;
            SqlDataAdapter adapter = new SqlDataAdapter("select * from usuario", conex);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        static public ConfiguracaoMenu GetMenuConfig(int id)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conex;
            command.CommandText = "select * from confUsu where Id = @id";
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            conex.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {                
                ConfiguracaoMenu configuracao = new ConfiguracaoMenu();
                configuracao.id = id;
                configuracao.image = reader.GetString(1);
                configuracao.corR = reader.GetInt32(2);
                configuracao.corG = reader.GetInt32(3);
                configuracao.corB = reader.GetInt32(4);
                configuracao.tamanho_texto = float.Parse(reader.GetString(5));
                configuracao.nome_fonte = reader.GetString(6);
                conex.Close();
                return configuracao;
            }
            else
            {
                conex.Close();
                return null;
            }
        } 
        static public void RemoveUser(int id)
        {
            SqlCommand del = new SqlCommand();
            del.Connection = conex;
            del.CommandText = "delete from usuario where Id =" + id;
            conex.Open();
            del.ExecuteNonQuery();
            conex.Close();
        }
        static public DataTable SelectType()
        {
            DataTable table;
            SqlDataAdapter adapter = new SqlDataAdapter("select tipo from usuario", conex);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        static public void AdicionaUser(string login, string senha, string tipo)
        {
            SqlCommand add = new SqlCommand();
            add.Connection = conex;
            add.Parameters.AddWithValue("@login", login);
            add.Parameters.AddWithValue("@senha", senha);
            add.Parameters.AddWithValue("@tipo", tipo);
            add.CommandText = "insert into usuario values (@login, @senha, @tipo)";
            conex.Open();
            add.ExecuteNonQuery();
            conex.Close();
        }
        static public void UpdateUser(int id, string senha)
        {
            SqlCommand att = new SqlCommand();
            att.Connection = conex;
            att.Parameters.AddWithValue("@id", id);
            att.Parameters.AddWithValue("@senha", senha);
            att.CommandText = "UPDATE usuario SET senha = @senha WHERE Id = @id";
            conex.Open();
            att.ExecuteNonQuery();
            conex.Close();
        }
        static public void InsertFesta(string nome, string dataFesta, string responsavel)
        {
            SqlCommand add = new SqlCommand();
            add.Connection = conex;
            add.Parameters.AddWithValue("@nome", nome);           
            add.Parameters.Add("@dataFesta", SqlDbType.DateTime).Value = dataFesta;
            add.Parameters.AddWithValue("@responsavel", responsavel);
            add.CommandText = "insert into festa values (@nome, @dataFesta, @responsavel)";
            conex.Open();
            add.ExecuteNonQuery();
            conex.Close();
        }
        static public void InsertConfig(ConfiguracaoMenu config)
        {
            SqlCommand select = new SqlCommand("SELECT Id from ConfUsu where Id = @id", conex);
            select.Parameters.Add("@id", SqlDbType.Int).Value = config.id;
            conex.Open();
            object resposta = select.ExecuteScalar();
            SqlCommand grava = new SqlCommand();
            grava.Connection = conex;
            grava.Parameters.Add("@id", SqlDbType.Int).Value = config.id;
            grava.Parameters.Add("@imagem", SqlDbType.VarChar).Value = config.image;
            grava.Parameters.Add("@corR", SqlDbType.Int).Value = config.corR;
            grava.Parameters.Add("@corG", SqlDbType.Int).Value = config.corG;
            grava.Parameters.Add("@corB", SqlDbType.Int).Value = config.corB;
            grava.Parameters.Add("@tamanhoFonte", SqlDbType.VarChar).Value = config.tamanho_texto;
            grava.Parameters.Add("@nomeFonte", SqlDbType.VarChar).Value = config.nome_fonte;

            if (resposta == null)
            {
                grava.CommandText = "INSERT INTO confUsu VALUES (@id, @imagem, @corR, @corG, @corB, @tamanhoFonte, @nomeFonte)";

            }
            else
            {
                grava.CommandText = "UPDATE confUsu set imagem = @imagem, corR = @corR, corG = @corG, corB = @corB, tamanhoFonte = @tamanhoFonte, nomeFonte = @nomeFonte";

            }
            grava.ExecuteNonQuery();
            conex.Close();
        }
        static public DataTable GetFesta()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM festa",conex);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        static public DataTable GetFestaNome(string nome, string resp)
        {
            SqlDataAdapter adapter;
            if (!(nome.Equals("")))
            {
                if (!(resp.Equals(""))){
                    adapter = new SqlDataAdapter("SELECT * FROM festa where nome like @nome or responsavel like @resp", conex);
                    adapter.SelectCommand.Parameters.AddWithValue("@nome", "%" + nome + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@resp", "%" + resp + "%");
                }
                else
                {
                    adapter = new SqlDataAdapter("SELECT * FROM festa where nome like @nome", conex);
                    adapter.SelectCommand.Parameters.AddWithValue("@nome", "%" + nome + "%");
                }
            }
            else
            {
                adapter = new SqlDataAdapter("SELECT * FROM festa where responsavel like @resp", conex);
                adapter.SelectCommand.Parameters.AddWithValue("@resp", "%" + resp + "%");
            }
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        static public DataTable GetFestaTime(string horaInicial, string HoraFinal)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM festa where dataFesta between @dataInicio and @dataFinal", conex);
            adapter.SelectCommand.Parameters.Add("@dataInicio", SqlDbType.DateTime).Value = horaInicial;
            adapter.SelectCommand.Parameters.Add("@dataFinal", SqlDbType.DateTime).Value = HoraFinal;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        static public Usuario CapturaUsuario(string login, string password)
        {
            SqlCommand checkLogin = new SqlCommand();
            checkLogin.Connection = conex;

            checkLogin.Parameters.AddWithValue("@login", login);
            checkLogin.Parameters.AddWithValue("@passwd", password);

            checkLogin.CommandText = "SELECT * from usuario WHERE login = @login AND senha = @passwd";
            conex.Open();
            SqlDataReader sqlDataReader = checkLogin.ExecuteReader();
            if (sqlDataReader.Read())
            {
                Usuario usuario = new Usuario(sqlDataReader.GetInt32(0),sqlDataReader.GetString(1),sqlDataReader.GetString(2),sqlDataReader.GetString(3));
                conex.Close();
                return usuario;
            }
            else
            {
                conex.Close();
                return null;
            }  
        }
    }
}
