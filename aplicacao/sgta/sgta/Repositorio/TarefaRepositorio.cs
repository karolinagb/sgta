using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using sgta.Models;

namespace sgta.Repositorio
{
    public class TarefaRepositorio
    {
        private SqlConnection _con;

        //Metodo para string de conexao
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }

        //Cadastrar uma tarefa

        public bool CadastrarTarefa(Tarefas tarefaObj)
        {
            //Chamado o metodo de conexao criado
            Connection();

            int i;

            //Trabalhando com as procedures criadas no Banco de dados
            using (SqlCommand command = new SqlCommand("IncluirTarefa", _con))
            {
                //Informando que é uma procedure (necessario para trabalhar com procedure)
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Informando parametros da procedure
                command.Parameters.AddWithValue("@nome", tarefaObj.nome);
                command.Parameters.AddWithValue("@dataCadastro", tarefaObj.dataCadastro);
                command.Parameters.AddWithValue("@dataLimite", tarefaObj.dataLimite);

                //Abrir a conexão 
                _con.Open();

                //Se for com sucesso o ExecuteNonQuery retorna quantas linhas foram afetadas
                i = command.ExecuteNonQuery();

            }

            //Fechar a conexão
            _con.Close();

            //i sendo maior que 1 temos true
            return i >= 1;
        }

        //Obter as tarefas criando uma lista
        public List<Tarefas> ObterTarefas()
        {
            //Chamar conexao
            Connection();

            //Instanciando lista
            List<Tarefas> TarefasList = new List<Tarefas>();
            
            //Usando a procedure
            using (SqlCommand command = new SqlCommand("SelecionarTarefas", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _con.Open();

                //Verifica na tabela os registros (instancia do método ExecuteReader)
                SqlDataReader reader = command.ExecuteReader();

                //Condição enquanto reader esta lendo trazendo cada linha
                while (reader.Read())
                {
                    Tarefas tarefa = new Tarefas()
                    {
                        //Convertendo para inteiro o conteudo de reader no campo id e passando para variavel id
                        id = Convert.ToInt32(reader["id"]),
                        nome = Convert.ToString(reader["nome"]),
                        dataCadastro = Convert.ToString(reader["dataCadastro"]),
                        dataLimite = Convert.ToString(reader["dataLimite"])
                    };

                    //Adicionando o objeto tarefa na lista TarefasList
                    TarefasList.Add(tarefa);
                }

                _con.Close();

                return TarefasList;

            }
        }

        //Atualizar uma tarefa
        public bool AtualizarTarefa(Tarefas tarefaObj)
        {
            //Chamado o metodo de conexao criado
            Connection();

            int i;

            //Trabalhando com as procedures criadas no Banco de dados
            using (SqlCommand command = new SqlCommand("AtualizarTarefa", _con))
            {
                //Informando que é uma procedure (necessario para trabalhar com procedure)
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Informando parametros da procedure
                command.Parameters.AddWithValue("@id", tarefaObj.id);
                command.Parameters.AddWithValue("@nome", tarefaObj.nome);
                command.Parameters.AddWithValue("@dataCadastro", tarefaObj.dataCadastro);
                command.Parameters.AddWithValue("@dataLimite", tarefaObj.dataLimite);

                //Abrir a conexão 
                _con.Open();

                //Se for com sucesso o ExecuteNonQuery retorna quantas linhas foram afetadas
                i = command.ExecuteNonQuery();

            }

            //Fechar a conexão
            _con.Close();

            //i sendo maior que 1 temos true
            return i >= 1;
        }

        //Excluir uma tarefa por id
        public bool ExcluirTarefa(int id)
        {
            //Chamado o metodo de conexao criado
            Connection();

            int i;

            //Trabalhando com as procedures criadas no Banco de dados
            using (SqlCommand command = new SqlCommand("ExcluirTarefaPorId", _con))
            {
                //Informando que é uma procedure (necessario para trabalhar com procedure)
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Informando parametros da procedure
                command.Parameters.AddWithValue("@id", id);

                //Abrir a conexão 
                _con.Open();

                //Se for com sucesso o ExecuteNonQuery retorna quantas linhas foram afetadas
                i = command.ExecuteNonQuery();

            }

            //Fechar a conexão
            _con.Close();

            //i sendo maior que 1 temos true
            if (i >= 1)
            {
                return true;
            }

            return false;
        }

        //Obter tarefas do dia
        public List<Tarefas> ObterTarefasPorData(string data)
        {
            //Chamar conexao
            Connection();

            //Instanciando lista
            List<Tarefas> TarefasList = new List<Tarefas>();

            //Usando a procedure
            using (SqlCommand command = new SqlCommand("SelecionarTarefaPorData", _con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _con.Open();

                command.Parameters.AddWithValue("@dataLimite", data);

                //Verifica na tabela os registros (instancia do método ExecuteReader)
                SqlDataReader reader = command.ExecuteReader();

                //Condição enquanto reader esta lendo trazendo cada linha
                while (reader.Read())
                {
                    Tarefas tarefa = new Tarefas()
                    {
                        //Convertendo para inteiro o conteudo de reader no campo id e passando para variavel id
                        id = Convert.ToInt32(reader["id"]),
                        nome = Convert.ToString(reader["nome"]),
                        dataCadastro = Convert.ToString(reader["dataCadastro"]),
                        dataLimite = Convert.ToString(reader["dataLimite"])
                    };

                    //Adicionando o objeto tarefa na lista TarefasList
                    TarefasList.Add(tarefa);
                }

                _con.Close();

                return TarefasList;

            }
        }
    }
}