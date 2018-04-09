using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Dapper.Contrib.Extensions;

namespace FrameWork.Repository
{

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        protected string ConnectionString { get; set; }

        #region ExecuteReader
        protected IEnumerable<T> ExecuteReader<T>(NpgsqlCommand sqlCommand, Func<IDataReader, T> materializeMethod)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

                var sqlDataReader = sqlCommand.ExecuteReader();
                var lista = new List<T>();

                while (sqlDataReader.Read())
                {
                    lista.Add(materializeMethod(sqlDataReader));
                }

                sqlConnection.Close();

                return lista;
            }
        }
        #endregion

        #region ExecuteNonQuery
        protected void ExecuteNonQuery(NpgsqlCommand sqlCommand)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {

                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        #endregion

        #region ExecuteScalar
        protected object ExecuteScalar(NpgsqlCommand sqlCommand)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

                var retorno = sqlCommand.ExecuteScalar();
                sqlConnection.Close();

                return retorno;
            }
        }
        #endregion

        public List<TEntity> GetAll()
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                return (List<TEntity>) sqlConnection.GetAll<object>();
            }
        }

        public TEntity Get(int id)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                return (TEntity)sqlConnection.Get<object>(id);
            }
        }

        public bool Update(object entity)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                return sqlConnection.Update(entity);
            }
        }

        public long Insert(object entity)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
               return sqlConnection.Insert(entity);
            }
        }

    }

    public interface IBaseRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        bool Update(object entity);
        long Insert(object entity);
    }
}