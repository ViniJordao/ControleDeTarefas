using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas
{
    public class ControladorTarefas
    {
        public  void InserirTarefa(Tarefas tarefa)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sqlInsercao =
                @"INSERT INTO TBTAREFAS
                    (
                        [TITULO],
                        [DATACRIACAO]
                        [DATAFINALIZACAO],
                        [PRIORIDADE],
                        [PERCENTUAL],
                    )
                    VALUES
                    (
                        @TITULO,
                        @DATACRIACAO,
                        @DATAFINALIZACAO,
                        @PERCENTUAL,
                        @PRIORIDADE
                    )";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("DATAFINALIZACAO", tarefa.DataFinalizacao);
            comandoInsercao.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

           //comandoInsercao.ExecuteNonQuery();
            // object id = comandoInsercao.ExecuteScalar();

            //Tarefas.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public  void AtualizarTarefas(Tarefas tarefa)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = conexaoComBanco;

            string sqlAtualizacao =
                 @"UPDATE TBTAREFAS 
                 SET	
                        [TITULO] = @TITULO,
                        [DATACRIACAO] = @DATACRIACAO,
                        [DATAFINALIZACAO] = @DATAFINALIZACAO,
                        [PERCENTUAL] = @PERCENTUAL,
                        [PRIORIDADE] = @PRIORIDADE,
                 WHERE 
                  [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", tarefa.Id);
            comandoAtualizacao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoAtualizacao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoAtualizacao.Parameters.AddWithValue("DATAFINALIZACAO", tarefa.DataFinalizacao);
            comandoAtualizacao.Parameters.AddWithValue("PERCENTUAL", tarefa.Percentual);
            comandoAtualizacao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

           

            conexaoComBanco.Close();
        }
        public  void ExcluirTarefas(Tarefas tarefa)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;

            string sqlExclusao =
                @"DELETE FROM TBTAREFAS	                
                 WHERE 
                  [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", tarefa.Id);

            comandoExclusao.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
        public Tarefas SelecionarTarefasPorId(int idPesquisando)
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                        [TITULO],
                        [DATACRIACAO]
                        [DATAFINALIZACAO],
                        [PERCENTUAL],
                        [PRIORIDADE],
                    FROM 
                        TBTAREFAS
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisando);

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            if (leitorTarefas.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorTarefas["ID"]);
            string titulo = Convert.ToString(leitorTarefas["NOME"]);
            DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
            DateTime dataFinalizacao = Convert.ToDateTime(leitorTarefas["DATAFINALIZACAO"]);
            string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
            string prioridade = Convert.ToString(leitorTarefas["PRIORIDADE"]);


            Tarefas tarefa = new Tarefas(id, titulo, dataCriacao, dataFinalizacao, percentual, prioridade);
            tarefa.Id = id;

            conexaoComBanco.Close();

            return tarefa;
        }

        public  List<Tarefas> SelecionarTodasTarefas()
        {
            SqlConnection conexaoComBanco = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;

            string sqlSelecao =
                @"SELECT 
                        [TITULO],
                        [DATACRIACAO]
                        [DATAFINALIZACAO],
                        [PERCENTUAL],
                        [PRIORIDADE],
                    FROM 
                        TBTAREFAS";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefas> tarefas = new List<Tarefas>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);
                string titulo = Convert.ToString(leitorTarefas["NOME"]);
                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);
                DateTime dataFinalizacao = Convert.ToDateTime(leitorTarefas["DATAFINALIZACAO"]);
                string percentual = Convert.ToString(leitorTarefas["PERCENTUAL"]);
                string prioridade = Convert.ToString(leitorTarefas["PRIORIDADE"]);

                Tarefas tarefa = new Tarefas(id, titulo, dataCriacao, dataFinalizacao, percentual, prioridade)
                {
                    Id = id
                };

                tarefas.Add(tarefa);
            }

            conexaoComBanco.Close();
            return tarefas;
        }


        private static SqlConnection AbrirConexao()
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
