using Microsoft.AspNetCore.Mvc;

namespace RidePoint.Controllers
{
    [Route("PrivacyPolicy")]
    public class PrivacyPolicyController : Controller
    {

        [HttpGet("", Name = "PrivacyPolicyIndex")]
        public IActionResult Index()
        {
            return View();
        }
    }
}