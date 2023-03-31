using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep
{
    public abstract class BaseRepositroy<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _db;

        public BaseRepositroy()
        {
            _db = DBtool.DbInstance;
        }
        void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }
        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }
        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destory(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestoryRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }

        public T FirstOrDefoult(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetDeleteds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T unchangedEntity = Find(item.ID);
            _db.Entry(unchangedEntity).CurrentValues.SetValues(item);
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
