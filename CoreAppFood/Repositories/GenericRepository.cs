

using CoreAppFood.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace CoreAppFood.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        public Context context = new Context();


        public List<T> TList()
        {
            return context.Set<T>().ToList();
        }


        public void TAdd(T param)
        {
            context.Set<T>().Add(param);
            context.SaveChanges();
        }

        public void TDelete(T param)
        {
            context.Set<T>().Remove(param);
            context.SaveChanges();
        }

        public void TUpdate(T param)
        {
            context.Set<T>().Update(param);
            context.SaveChanges();
        }

        public T TGet(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> getTList(string param)
        {
            return context.Set<T>().Include(param).ToList();
        }

        public List<T> Lst(Expression<Func<T,bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }
    }
}
