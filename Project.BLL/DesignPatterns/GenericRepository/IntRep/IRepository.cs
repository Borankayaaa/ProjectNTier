using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List Commands
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetModifieds();
        List<T> GetDeleteds();

        //Modify Commands

        void Add(T item);

        void AddRange(List<T> list);

        void Delete(T item); //Pasife Çekmek

        void DeleteRange(List<T> list);

        void Update(T item);

        void UpdateRange(List<T> list);

        void Destory(T item);

        void DestoryRange(List<T> list);

        //Linq Commands
        // _db.Products.Where(x=>x.ProductName.Contains("be")).ToList();

        List<T> Where(Expression<Func<T,bool>> exp);

        bool any(Expression<Func<T,bool>> exp);

        T FirstOrDefoult(Expression<Func<T, bool>> exp); 

        object Select(Expression<Func<T, object>> exp);  //_db.Products.Select(x=> new{})

        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //_db.Products.Selcet(x=> new productDTO{})

        // Find Command

        T Find(int id);


    }
}
