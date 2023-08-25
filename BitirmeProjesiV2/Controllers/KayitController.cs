using Microsoft.AspNetCore.Mvc;
using BitirmeProjesiV2;
using BitirmeProjesiV2.Models.DB;

namespace BitirmeProjesiV2.Controllers
{
    public class KayitController : Controller
    {
        private readonly ILogger<KayitController> _logger;
        private readonly CorumGeziContext _context;
        public KayitController(ILogger<KayitController> logger, CorumGeziContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        public IActionResult Kayit()
        {            
                        
            return View();
        }
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Namesurname,Email,Gender,Birthdate,Createddate,Telnr1,Telnr2")] User user)
        {

            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Kayit));
            }
            return View();
        }
    }
}
