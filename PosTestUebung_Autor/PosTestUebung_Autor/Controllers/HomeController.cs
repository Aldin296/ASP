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
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem eintrag1 = new SelectListItem("Verry Good", "5");
            selectListItems.Add(eintrag1);
            SelectListItem eintrag2 = new SelectListItem("Good", "4");
            selectListItems.Add(eintrag2);
            SelectListItem eintrag3 = new SelectListItem("Mid", "3");
            selectListItems.Add(eintrag3);
            SelectListItem eintrag4 = new SelectListItem("Ok", "2");
            selectListItems.Add(eintrag4);
            SelectListItem eintrag5 = new SelectListItem("Awful", "1");
            selectListItems.Add(eintrag5);

            // Die Übergabe erfolgt über das ViewData-Dictionary
            ViewData["Kategorien"] = selectListItems;


            if (id is not null && id>0)
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

        public IActionResult AddBuch(Buch book)
        {
            if (book.AutorId is not null && book.AutorId > 0)
            {
                Autor? autorFromDb = _context.Autoren.FirstOrDefault(x => x.Id == book.AutorId);

                if (autorFromDb is not null)
                {
                    List<string> genres = book.Genres[0].Split(",").ToList();
                    book.Genres = genres;

                    autorFromDb.Buecher.Add(book);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var authorFromDB = _context.Autoren.Include(author => author.Buecher).FirstOrDefault(m => m.Id == id);
            if (authorFromDB is null)
            {
                return NotFound();
            }
            _context.Autoren.Remove(authorFromDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
