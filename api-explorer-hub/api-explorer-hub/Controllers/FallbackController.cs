using Microsoft.AspNetCore.Mvc;

namespace api_explorer_hub.Controllers
{
    [Route("[controller]")]
    public class FallbackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "index.html"
                    ), "text/HTML"
            );
        }
    }
}
