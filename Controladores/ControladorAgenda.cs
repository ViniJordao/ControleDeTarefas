using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Controladores
{
    public class ControladorAgenda
    {
        public void InserirNaAgenda(Agenda agenda)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
               @"INSERT INTO TBAGENDA
                    (
                        [NOME],
                        [EMAIL]
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO],
                    )
                    VALUES
                    (
                        @NOME,
                        @EMAIL,
                        @TELEFONE,
                        @EMPRESA,
                        @CARGO
                    )";
            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("NOME", agenda.Nome);
            comandoInsercao.Parameters.AddWithValue("EMAIL", agenda.Email);
            comandoInsercao.Parameters.AddWithValue("TELEFONE", agenda.Telefone);
            comandoInsercao.Parameters.AddWithValue("EMPRESA", agenda.Empresa);
            comandoInsercao.Parameters.AddWithValue("CARGO", agenda.Cargo);

            comandoInsercao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }


        public void AtualizarAgenda(Agenda agenda)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = conexaoComBanco;

            string sqlAtualizacao =
                 @"UPDATE TBAGENDA 
                 SET	
                        [NOME] = @NOME,
                        [EMAIL] = @EMAIL,
                        [TELEFONE] = @TELEFONE,
                        [EMPRESA] = @EMPRESA,
                        [CARGO] = @CARGO,
                 WHERE 
                  [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", agenda.Id);
            comandoAtualizacao.Parameters.AddWithValue("NOME", agenda.Nome);
            comandoAtualizacao.Parameters.AddWithValue("EMAIL", agenda.Email);
            comandoAtualizacao.Parameters.AddWithValue("TELEFONE", agenda.Telefone);
            comandoAtualizacao.Parameters.AddWithValue("EMPRESA", agenda.Empresa);
            comandoAtualizacao.Parameters.AddWithValue("CARGO", agenda.Cargo);

            comandoAtualizacao.ExecuteNonQuery();

            conexaoComBanco.Close();



        }
        public void ExcluirAgenda(Agenda agenda)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                @"DELETE FROM TBAGENDA	                
                 WHERE 
                  [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", agenda.Id);

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public Agenda SelecionarAgendaPorId(int idPesquisando)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                        [NOME],
                        [EMAIL]
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO],
                    FROM 
                        TBAGENDA
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisando);

            SqlDataReader leitorAgenda = comandoSelecao.ExecuteReader();

            if (leitorAgenda.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorAgenda["ID"]);
            string nome = Convert.ToString(leitorAgenda["NOME"]);
            string email = Convert.ToString(leitorAgenda["EMAIL"]);
            string telefone = Convert.ToString(leitorAgenda["TELEFONE"]);
            string empresa = Convert.ToString(leitorAgenda["EMPRESA"]);
            string cargo = Convert.ToString(leitorAgenda["CARGO"]);


            Agenda agenda = new Agenda(id, nome, email, telefone, empresa, cargo);
            agenda.Id = id;

            conexaoComBanco.Close();

            return agenda;

        }

        public List<Agenda> SelecionarTodasAgenda()
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                        [NOME],
                        [EMAIL]
                        [TELEFONE],
                        [EMPRESA],
                        [CARGO],
                    FROM 
                        TBAGENDA";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorAgenda = comandoSelecao.ExecuteReader();

            List<Agenda> agendas = new List<Agenda>();

            while (leitorAgenda.Read())
            {
                int id = Convert.ToInt32(leitorAgenda["ID"]);
                string nome = Convert.ToString(leitorAgenda["NOME"]);
                string email = Convert.ToString(leitorAgenda["EMAIL"]);
                string telefone = Convert.ToString(leitorAgenda["TELEFONE"]);
                string empresa = Convert.ToString(leitorAgenda["EMPRESA"]);
                string cargo = Convert.ToString(leitorAgenda["CARGO"]);

                Agenda agenda = new Agenda(id, nome, email, telefone, empresa, cargo);
                agenda.Id = id;

               agendas.Add(agenda);
            }

            conexaoComBanco.Close();
            return agendas;
        }

        private SqlConnection AbrirConexao()
        {
            string enderecoDBTarefas =
                @"Data Source = (LocalDb)\MSSqlLocalDB; Initial Catalog = DBTarefas; Integrated Security = True; Pooling = False";

            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBTarefas;
            conexaoComBanco.Open();
            return conexaoComBanco;
        }
    }
}
