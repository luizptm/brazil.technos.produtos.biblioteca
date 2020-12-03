using Data.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Text;

namespace Data.ODBC
{
    public class ProdutoOdbcData : IProdutoOdbcData
    {
        private OdbcConnection connection;
        private string connectionString = "";

        public ProdutoOdbcData()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GrupoTechnos"].ConnectionString;
            connection = new OdbcConnection(connectionString);
        }

        Produto IRepository<Produto>.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Produto> IRepository<Produto>.GetAll()
        {
            var data = new List<Produto>();
            using (this.connection)
            {
                OdbcCommand MyCommand = new OdbcCommand();
                MyCommand.CommandText = "SELECT * FROM Produto";
                MyCommand.Connection = connection;
                OdbcDataReader MyDataReader;
                MyDataReader = MyCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    Produto p = new Produto
                    {
                        Codigo = (int?)MyDataReader.GetValue(0),
                        Descricao = MyDataReader.GetValue(1).ToString()
                    };
                    data.Add(p);
                    MyDataReader.Read();
                }
                //Close all resources
                MyDataReader.Close();
                connection.Close();
            }
            return data;
        }

        PagedResultDto<Produto> IRepository<Produto>.GetPagedData(int maxCountReg, int skip)
        {
            throw new NotImplementedException();
        }

        List<Produto> IRepository<Produto>.Find(Produto produto)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Produto>.Salvar(Produto entity)
        {
            if (entity.Codigo == null)
            {
                string sql =
                    "INSERT INTO Produto (Descricao, Marca, Preco, DataCriacao, DataLancamento, TipoProduto) " +
                    "Values(@Descricao, @Marca, Preco, @DataCadastro, @DataLancamento, @TipoProduto)";
                sql = sql.Replace("@Descricao", "'" + entity.Descricao + "'");
                sql = sql.Replace("@Marca", "'" + entity.Marca + "'");
                sql = sql.Replace("@Preco", entity.Preco.ToString());
                sql = sql.Replace("@DataCadastro", "'" + entity.DataCadastro + "'");
                sql = sql.Replace("@DataLancamento", "'" + entity.DataLancamento + "'");
                sql = sql.Replace("@TipoProduto", entity.TipoProduto.Id.ToString());
                OdbcCommand command = new OdbcCommand(sql);
                using (this.connection)
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            else
            {
                string sql =
                    "UPDATE Produto Nome = @Nome, Descricao = @Descricao, Marca = @Marca, " +
                    "Preco = @Marca, DataCadastro = @DataCadastro, DataLancamento = @DataLancamento, TipoProduto = @TipoProduto " +
                    " WHERE Codigo = @Codigo";
                sql = sql.Replace("@Descricao", "'" + entity.Descricao + "'");
                sql = sql.Replace("@Marca", entity.Marca.Id.ToString());
                sql = sql.Replace("@Preco", entity.Preco.ToString());
                sql = sql.Replace("@DataCadastro", "'" + entity.DataCadastro + "'");
                sql = sql.Replace("@DataLancamento", "'" + entity.DataLancamento + "'");
                sql = sql.Replace("@TipoProduto", entity.TipoProduto.Id.ToString());
                sql = sql.Replace("@Codigo", entity.Codigo.ToString());
                OdbcCommand command = new OdbcCommand(sql);
                using (this.connection)
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
        }

        bool IRepository<Produto>.Excluir(int id)
        {
            string sql = "DELETE Produto WHERE Codigo = @Codigo";
            sql = sql.Replace("@Codigo", id.ToString());
            OdbcCommand command = new OdbcCommand(sql);
            using (this.connection)
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        bool IRepository<Produto>.Excluir(Produto entity)
        {
            string sql = "DELETE Produto WHERE Codigo = @Codigo";
            sql = sql.Replace("@Codigo", entity.Codigo.ToString());
            OdbcCommand command = new OdbcCommand(sql);
            using (this.connection)
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
