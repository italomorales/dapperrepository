using System;
using System.Collections.Generic;
using FrameWork.Repository;
using FrameWork.Model;
using Microsoft.Extensions.Logging;

namespace FrameWork.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly ILogger<ICustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerServices(ILogger<ICustomerService> logger,
                                ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        #region Get
        public Customer Get(int id)
        {
            try
            {
                return _customerRepository.Get(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cliente");
                throw;
            }
            
        }
        #endregion

        #region GetAll
        public List<Customer> GetAll()
        {
            try
            {
                return _customerRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cliente");
                throw;
            }

        }
        #endregion
    }

    public interface ICustomerService
    {
        Customer Get(int id);
        List<Customer> GetAll();
    }
}
