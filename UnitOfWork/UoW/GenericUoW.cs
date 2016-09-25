using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnitOfWork.UoW;

namespace UnitOfWork.UoW
{
        public class GenericUoW : IGenericUoW
        {
            private readonly DbContext entities = null;
            public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

            public GenericUoW(DbContext entities)
            {
                this.entities = entities;
            }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(entities);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            entities.SaveChanges();
        }
    }
}