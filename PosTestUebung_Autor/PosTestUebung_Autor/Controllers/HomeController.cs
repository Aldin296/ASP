using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosTestUebung_Autor.Data;
using PosTestUebung_Autor.Models;
using System.Diagnostics;

namespace PosTestUebung_Autor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var authoren = _context.Autoren.Include(authoren => authoren.Buecher).ToList();
            return View(authoren);
        }

        
        public IActionResult CreateAuthorForm()
        {
            return View();

        }

        public IActionResult CreateAuthor(Autor autor)
        {
            _context.Autoren.Add(autor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBuchForm(int? id)
        {
            if(id is not null && id>0)
            {
                var authorenFromDB = _context.Autoren.FirstOrDefault(s=>s.Id == id);
                if(authorenFromDB is not null)
                {
                    Buch buch = new();
                    buch.AutorId = id;
                    return View(buch);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBuch(Buch buch)
        {
            if(buch.AutorId is not null && buch.AutorId > 0)
            {
                Autor? authorFromDB = _context.Autoren.FirstOrDefault(x=>x.Id == buch.AutorId);
                if(authorFromDB is not null)
                {
                    authorFromDB.Buecher.Add(buch);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
