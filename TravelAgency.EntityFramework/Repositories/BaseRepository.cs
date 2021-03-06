﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccessLayer.Repositories;

namespace TravelAgency.EntityFramework.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TravelAgencyContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(TravelAgencyContext context)
        {
            this.context = context ?? throw new ArgumentNullException();
            dbSet = this.context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity == null)
                return;

            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public void Save(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
