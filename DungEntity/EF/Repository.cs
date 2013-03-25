using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using Domain.RepositoryInterface;
using System;

namespace EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context dataContext;

        private readonly IDbSet<T> dbset;

        public Repository()
        {
            dataContext = new Context();
            dbset = DataContext.Set<T>();            
        }

        public DbContext DataContext
        {
            get { return dataContext ?? (dataContext = new Context()); }
        }

        public virtual void Add(T entity)
        {            
            dbset.Add(entity);            
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }


        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}