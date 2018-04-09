using System.Collections.Generic;
using System.Data;
using System.Linq;
using FrameWork.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace FrameWork.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("framework");
        }

        #region Materialize
        private static Customer Materialize(IDataRecord record)
        {
            var customer = new Customer
            {
                Id = (int)record["id"],
                Name = (string)record["name"],
            };

            return customer;

        }
        #endregion

        #region Get
        public List<Customer> Get(Customer customer)
        {
            var sqlCommand = new NpgsqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "p_customer_list"
            };

            sqlCommand.Parameters.Add(new NpgsqlParameter("pName", NpgsqlDbType.Varchar));
            sqlCommand.Parameters["pName"].Value = customer.Name;
            
            return ExecuteReader(sqlCommand, Materialize).ToList();

        }
        #endregion
        
    }

    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        List<Customer> Get(Customer customer);

    }
}
