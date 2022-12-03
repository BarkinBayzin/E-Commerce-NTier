using NTier.Core.Entity;
using NTier.Core.Entity.Enum;
using NTier.Core.Service;
using NTier.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Singleton Context için bu şekilde tanımlıyoruz.
        private static ProjectContext _context;
        public ProjectContext Context 
        {
            get
            {
                if(_context == null)
                {
                    _context = new ProjectContext();
                    return _context;
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }
        /// <summary>
        /// Add for one entity
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Save();
        }

        /// <summary>
        /// Add for list of entities
        /// </summary>
        /// <param name="items"></param>
        public void Add(List<T> items)
        {
            Context.Set<T>().AddRange(items);
            Save();
        }
        /// <summary>
        /// Check entity if exist
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>If get the entity return true, otherwise false</returns>
        public bool Any(Expression<Func<T, bool>> exp) => Context.Set<T>().Any(exp);
        /// <summary>
        /// Get take active entites
        /// </summary>
        /// <returns>Return all Entities when are active</returns>
        public virtual List<T> GetActives() => Context.Set<T>().Where(x => x.Status == Status.Active).ToList();
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>Return all entities</returns>
        public List<T> GetAll() => Context.Set<T>().ToList();
        /// <summary>
        /// Check entity with expression argument
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>return T entity if they exist</returns>
        public T GetByDefault(Expression<Func<T, bool>> exp) => Context.Set<T>().Where(exp).FirstOrDefault();
        /// <summary>
        /// Check entity with guid id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return T entity if they exist</returns>
        public T GetById(Guid id) => Context.Set<T>().Find(id);
        /// <summary>
        /// Check entities with expression argument
        /// </summary>
        /// <param name="exp"></param>
        /// <returns>return List<T> entity if they exists</returns>
        public List<T> GetDefaults(Expression<Func<T, bool>> exp) => Context.Set<T>().Where(exp).ToList();
        /// <summary>
        /// This method will be change status property for deleted version of enums.(For not destroy data)
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }
        /// <summary>
        /// Will be find removed data using id argument
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            T item = GetById(id);
            Remove(item);
        }
        /// <summary>
        /// Will be find list of removed data using expression argument
        /// </summary>
        /// <param name="exp"></param>
        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefaults(exp))
            {
                Remove(item);
            }
        }
        /// <summary>
        /// Save changes for db update
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return Context.SaveChanges();
        }
        /// <summary>
        /// First get updated data, after then using item argument will be set current values for updating.
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            T updated = GetById(item.Id);
            DbEntityEntry entry = Context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();            
        }

        //Singleton Pattern tarafı ile ilgili cache sorununu engellemek adına DetachEntity methodunu yazmalıyız!
        public void DetachEntity(T item)
        {
            Context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
