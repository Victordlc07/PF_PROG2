using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Interface
{
    public interface IGenericRepository <T>
    {
        T Create(T model);
        T FindById(int id);
        List<T> GetAll();
        OperationResult Update(T model);
        OperationResult Delete(T model);
    }
}
