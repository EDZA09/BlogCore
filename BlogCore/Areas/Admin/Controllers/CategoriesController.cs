using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IWorkUnity _workcontainer;
        private readonly ApplicationDbContext _ Context

        public IActionResult Index()
        {
            return View();
        }
    }
}
