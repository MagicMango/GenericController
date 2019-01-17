using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AGenericController.Models.Contexts
{
    public class GenericLayer<T> : IDisposable where T: class
    {
        private TestDBEntities context;

        public GenericLayer()
        {
            context = new TestDBEntities();
        }

        public List<T> GetAll() 
        {
            return context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Create(T element)
        {
            context.Set<T>().Add(element);
            context.Entry(element).State = EntityState.Added;
            context.SaveChanges();
            return true;
        }

        public bool Update(T element)
        {
            context.Set<T>().Attach(element);
            context.Entry(element).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool Delete(T element)
        {
            context.Set<T>().Attach(element);
            context.Entry(element).State = EntityState.Deleted;
            context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}