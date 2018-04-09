using FrameWork.Repository;
using FrameWork.Services;
using Microsoft.Extensions.DependencyInjection;
using FrameWork.WebApi.Controllers;

namespace FrameWork.WebApi.Container
{
    public static class ContainerBuilder
    {
        public static void ConfigureContainer(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerServices>();
            services.AddTransient<ICustomerController, CustomerController>();
        }
    }
}