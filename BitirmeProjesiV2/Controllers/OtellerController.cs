using Microsoft.AspNetCore.Mvc;
using BitirmeProjesiV2.Models.DB;

namespace BitirmeProjesiV2.Controllers
{
    public class OtellerController : Controller
    {
        private readonly CorumGeziContext _context;

        public OtellerController(CorumGeziContext context)
        {
            _context = context;
        }
        public IActionResult Oteller()
        {
            return View();
        }
    }
}
