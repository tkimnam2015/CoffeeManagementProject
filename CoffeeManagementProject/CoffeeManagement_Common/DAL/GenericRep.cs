using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoffeeManagement.Common.DAL
{
    public class GenericRep<C, T> : IGenericRep<T> where T : class where C : DbContext, new()
    {
        #region -- Fields --

        /// <summary>
        /// The entities
        /// </summary>
        public C _dbContext;

        #endregion -- Fields --

        #region -- Properties --

        /// <summary>
        /// The database context
        /// </summary>
        public C Context
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        #endregion -- Properties --

        #region -- Implements --

        /// <summary>
        /// Create the model
        /// </summary>
        /// <param name="m">The model</param>
        public void Create(T m)
        {
            _dbContext.Set<T>().Add(m);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Create list model
        /// </summary>
        /// <param name="l">List model</param>
        public void Create(List<T> l)
        {
            _dbContext.Set<T>().AddRange(l);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Read by
        /// </summary>
        /// <param name="p">Predicate</param>
        /// <returns>Return query data</returns>
        public IQueryable<T> Read(Expression<Func<T, bool>> p)
        {
            return _dbContext.Set<T>().Where(p);
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public virtual T Read(int id)
        {
            return null;
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="code">Secondary key</param>
        /// <returns>Return the object</returns>
        public virtual T Read(string code)
        {
            return null;
        }

        /// <summary>
        /// Update the model
        /// </summary>
        /// <param name="m">The model</param>
        public void Update(T m)
        {
            _dbContext.Set<T>().Update(m);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update list model
        /// </summary>
        /// <param name="l">List model</param>
        public void Update(List<T> l)
        {
            _dbContext.Set<T>().UpdateRange(l);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Return query all data
        /// </summary>
        public IQueryable<T> All
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        #endregion -- Implements --

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public GenericRep()
        {
            _dbContext = new C();
        }

        /// <summary>
        /// Update the model
        /// </summary>
        /// <param name="old">The old model</param>
        /// <param name="new">The new model</param>
        protected object Update(T old, T @new)
        {
            _dbContext.Entry(old).State = EntityState.Modified;
            var res = _dbContext.Set<T>().Add(@new);
            return res;
        }

        /// <summary>
        /// Delete the model
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the object</returns>
        protected T Delete(T m)
        {
            var t = _dbContext.Set<T>().Remove(m);
            return t.Entity;
        }

        #endregion -- Methods --
    }
}