using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data.Repository.IRepository
{
    public interface IWorkUnity : IDisposable
    {
        ICategoryRepository Categoria { get; }
        //TODO:: Agregar los demas repositorios

        void Save();
    }
}
