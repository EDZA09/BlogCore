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
        public ICategoryRepository Categoria => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}
