using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IWorkUnity _workcontainer;
        private readonly ApplicationDbContext _context;
        public CategoriesController(IWorkUnity workcontainer  ,ApplicationDbContext
            context)
        {
            _context = context;
            _workcontainer = workcontainer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _workcontainer.Categoria.Add(category);
                _workcontainer.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = new Category();
            category = _workcontainer.Categoria.Get(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _workcontainer.Categoria.Update(category);
                _workcontainer.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        #region Lamadas a la Api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opción 1
            return Json(new { data = _workcontainer.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _workcontainer.Categoria.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error al borrar la Categoria" });

            }

            _workcontainer.Categoria.Remove(objFromDb);
            _workcontainer.Save();
            return Json(new { success = true, message="Categoría borrada correctamente" });
        }

        #endregion
    }
}
