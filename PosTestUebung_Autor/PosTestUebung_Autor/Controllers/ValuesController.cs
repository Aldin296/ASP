using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosTestUebung_Autor.Data;
using PosTestUebung_Autor.Models;

namespace PosTestUebung_Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Fill")]
        public void FillData()
        {
            Autor autor = new Autor() {Name="Manuel", Age=19, Description="Manuel ist ein toller Author mit Alzheimer" };
            Buch b1 = new Buch() { Title = "Manuels Krankenhausbesuch",Genres = new List<string> { "Gestank", "Würgen", "Ersticken" }, Pagecount = 420, Stars = 5 };
            Buch b2 = new Buch() { Title = "Manuels Schulbesuich", Genres = new List<string> { "Tot", "Mord", "Sclaganfall" }, Pagecount = 690, Stars = 3 };

            autor.Buecher.Add(b1);
            autor.Buecher.Add(b2);

            _context.Autoren.Add(autor);
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Autor> GetAuthoren()
        {
            var authoren = _context.Autoren.Include(authoren => authoren.Buecher).ToList();
            return authoren;
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var authorFromDB = _context.Autoren.SingleOrDefault(x => x.Id == id);
            if (authorFromDB is null)
            {
                return NotFound();
            }
            _context.Autoren.Remove(authorFromDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
