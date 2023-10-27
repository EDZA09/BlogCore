using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IWorkUnity _workcontainer;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoriesController(IWorkUnity workcontainer, IWebHostEnvironment webHostEnvironment)
        {
            _workcontainer = workcontainer;
            _hostingEnvironment = webHostEnvironment;
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
        public IActionResult Create(ArticleVM articleVM)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
            }
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
