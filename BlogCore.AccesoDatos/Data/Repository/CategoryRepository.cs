using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace BlogCore.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListCategories()
        {
            return _context.Categories.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }
            ); 
        }

        public void Update(Category category)
        {
            var ObjectFromDB = _context.Categories.FirstOrDefault(s => s.Id == category.Id);
            ObjectFromDB.Name = category.Name;
            ObjectFromDB.Order = category.Order;

            _context.SaveChanges();
        }
    }
}
