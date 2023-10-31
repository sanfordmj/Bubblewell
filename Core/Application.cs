
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;

namespace Core
{
    [TestClass]
    public class Application
    {
        [TestMethod]
        public void Behaviors()
        {
           RouteController controller = new RouteController();
           IActionResult result = null;

            Task.Run(async ()=> result = await controller.GetRoute(new Guid(), new CancellationToken())).Wait();

           Assert.IsNotNull(result);

        }
    }
}