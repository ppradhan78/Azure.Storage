
namespace MicrosoftAzure.Storage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController()
        {
                
        }
        [HttpGet()]
        public string HealthCheck()
        {
            return "API working as expected  ";
        }
    }
}
