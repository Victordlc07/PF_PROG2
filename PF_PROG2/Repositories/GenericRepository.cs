using PF_PROG2.Entities;
using PF_PROG2.Interface;
using PF_PROG2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PF_PROG2.Repository
{ // la clase que te pasen debe heredar de baseentity, esta siendo restringido a los que estan en base entity
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private IncidentesDbContext dbContext;
        private DbSet<T> _set;

        public GenericRepository() //Constructor para incializar las variables
        {
            dbContext = new IncidentesDbContext();
            _set = dbContext.Set<T>();
        }
        public T Create(T model)
        {
          _set.Add(model);
           dbContext.SaveChanges();
                   
            return model;
        }

        public T FindById(int id)
        {
            return _set.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _set.Where(x => x.Borrado == 0 & x.Estatus == "A").ToList();
        }

        public OperationResult Update(T model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            dbContext.SaveChanges();
            return new OperationResult() { Success = true };
        }

        public OperationResult Delete(T model)
        {
            //soft delete
            dbContext.Entry(model).State = EntityState.Modified;
            model.Borrado = 1;
            model.Estatus = "I";
            model.FechaModificacion = DateTime.Now;
            dbContext.SaveChanges();

            return new OperationResult() { Success = true };
        }
    }
}
