using FrameWork.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameWork.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest : BaseTest
    {

        [TestMethod]
        public void ShouldSuccessWhenGetUser() => Assert.IsTrue(Provider.GetRequiredService<ICustomerController>().Get(1) != null);
    }
}
