using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //where ile yaptıgımız olay generic constraint
    //class ise referans tipi anlamına gelir
    //new :new'lenebilir olmalı (interfaceler new'lenemez)
    public interface IEntityRepository<T> where T:class ,IEntity,new () //T belirttiğimiz Car-Color-Brand vb
        //Ya entity olacak ya da IEntityden impelement olan bir nesne olacak   
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Null olması demek filtre vermeyedebilirsin demek
        T Get(Expression<Func<T, bool>> filter);//filtre vermezse tüm datayı istiyor
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
