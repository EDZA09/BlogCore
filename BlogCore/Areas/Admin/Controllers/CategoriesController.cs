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
                string mainRoot = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                if (articleVM.Article.Id == 0)
                {
                    // Nuevo Artículo
                    string fileName = Guid.NewGuid().ToString();
                    // ruta principal = wwwroot
                    // wwwroot/images/articles
                    var uploads = Path.Combine(mainRoot, @"images/articles");
                    var extensions = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extensions), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    _workcontainer.Articulo.Add(articleVM.Article);
                    _workcontainer.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            articleVM.ListaCategorias = _workcontainer.Categoria.GetListCategories();

            return View(articleVM);
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
