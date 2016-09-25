using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.UoW
{
    public interface IGenericUoW
    {
        IRepository<T> Repository<T>() where T : class;

        void SaveChanges();
    }
}
