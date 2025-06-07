using Microsoft.AspNetCore.Mvc;
using Prog5_2c_2025.Data;
using Prog5_2c_2025.Models;
using System.Linq;

namespace Prog5_2c_2025.Controllers
{
    public class CentroVacunacion2Controller : Controller
    {
        private AppDbContext _db;

        public CentroVacunacion2Controller(AppDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            //var cvs = _db.centrosDeVacunacion.ToList();
            IEnumerable<CentroVacunacion2> cvs = _db.centrosDeVacunacion2;
            return View(cvs);
        }

        public IActionResult Crear()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(CentroVacunacion2 cv)
        {
            if (cv.ProvinciaId < 1 || cv.ProvinciaId > 7)
            {
                ModelState.AddModelError("ProvinciaId", "Valores de provincia deben ser entre 1 y 7");
            }

            if (!ModelState.IsValid) { return View(cv); }

            _db.centrosDeVacunacion2.Add(cv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int? id)
        {
            if (id==null || id == 0) 
            {
                return NotFound();
            }

            var cvDb = _db.centrosDeVacunacion2.Find(id);// //FirstOrDefault(i=>i.CentroVacunacionId==id)//SingleOrDefault();
            //var cvDb2 = _db.centrosDeVacunacion.FirstOrDefault(i => i.CentroVacunacionId == id);

            if (cvDb==null)
            {
                return NotFound();
            }
            return View(cvDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(CentroVacunacion2 cv)
        {
            if (cv.ProvinciaId < 1 || cv.ProvinciaId > 7)
            {
                ModelState.AddModelError("ProvinciaId", "Valores de provincia deben ser entre 1 y 7");
            }

            if (!ModelState.IsValid) { return View(cv); }

            _db.centrosDeVacunacion2.Update(cv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
