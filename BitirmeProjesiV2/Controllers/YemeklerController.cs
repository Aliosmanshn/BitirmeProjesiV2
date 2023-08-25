using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiV2.Controllers
{
    public class YemeklerController : Controller
    {
        public IActionResult Yemekler()
        {
            return View();
        }
    }
}
