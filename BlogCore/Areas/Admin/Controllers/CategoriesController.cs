using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
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

        #region Lamadas a la Api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opción 1
            return Json(new { data = _workcontainer.Categoria.GetAll() });
        }

        #endregion
    }
}
