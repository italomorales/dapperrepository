using System.Collections.Generic;
using FrameWork.Services;
using FrameWork.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrameWork.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class CustomerController : Controller,  ICustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<Customer> GetAll() => _customerService.GetAll();
      
    }

    public interface ICustomerController  {
        List<Customer> GetAll();
    }

}
