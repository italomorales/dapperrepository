using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrameWork.WebApi.Container;

namespace FrameWork.Tests
{
    [TestClass]
    public class BaseTest
    {
        public ServiceProvider Provider { get; set; }

        [TestInitialize]
        public void Initialize()
        {
           IServiceCollection serviceCollection = new ServiceCollection();
           serviceCollection.AddLogging();
           ContainerBuilder.ConfigureContainer(serviceCollection);
           Provider = serviceCollection.BuildServiceProvider();
        }
       
    }
}
