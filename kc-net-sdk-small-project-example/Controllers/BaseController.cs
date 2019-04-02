using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace KcNetSdkSmallProjectExample.Controllers
{
    public class BaseController : Controller
    {
        public IDeliveryClient Client { get; }
        public BaseController()
        {
            Client = DeliveryClientBuilder
                .WithOptions(builder => builder
                    .WithProjectId("09fc0115-dd4d-00c7-5bd9-5f73836aee81")
                    .UseProductionApi
                    .WithMaxRetryAttempts(5)
                    .Build())
                .Build();
        }
    }
}
