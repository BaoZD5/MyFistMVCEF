using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVCEF.DAL
{
    public class SysBaseDAL<T> where T : class, new()
    {
        protected AccountContext db = new AccountContext();
        public void Add(T t)
        {
            db.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            db.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            db.Set<T>().Attach(t);
            db.Entry<T>(t).State = EntityState.Modified;
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return db.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return db.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
