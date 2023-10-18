using BlogCore.Data;
using BlogCore.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data.Repository
{
    public class WorkUnity : IWorkUnity
    {
        private readonly ApplicationDbContext _db;
        public WorkUnity(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoryRepository(_db);
        }
        public ICategoryRepository Categoria { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
