using PF_PROG2.Entities;
using PF_PROG2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {


        public T Create(T model)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(T model)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
