using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BlogCore.DataAccess.Data.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void Update(Article article)
        {
            var ObjectFromDB = _context.Articles.FirstOrDefault(s => s.Id == article.Id);
            ObjectFromDB.Name = article.Name;
            ObjectFromDB.Description = article.Description;
            ObjectFromDB.UrlImage = article.UrlImage;
            ObjectFromDB.CategoryId = article.CategoryId;

            //_context.SaveChanges();
        }
    }
}
