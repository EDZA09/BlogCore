using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWorkUnity _workUnity;

        public ArticlesController(ApplicationDbContext context, IWorkUnity workUnity)
        {
            _context = context;
            _workUnity = workUnity;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Lamadas a la Api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opción 1
            return Json(new { data = _workUnity.Articulo.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _workUnity.Articulo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error al borrar la Categoria" });

            }

            _workUnity.Articulo.Remove(objFromDb);
            _workUnity.Save();
            return Json(new { success = true, message = "Categoría borrada correctamente" });
        }

        #endregion

    }
}
