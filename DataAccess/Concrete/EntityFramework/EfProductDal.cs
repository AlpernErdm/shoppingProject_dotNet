using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //using =IDisposable pattern implementation for c# using bittiği anda garbage collector belleği temizler
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);//Bağlama yeri
                addedEntity.State = EntityState.Added;//İşlem yeri //State durum anlamına gelir ve metotları modified-added-deleted yani ekleme silme güncelleme
                context.SaveChanges(); //Kaydetme yeri//İşlemleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);//filtrelenmiş productı getirir SingleOrDefault sadece filtrelenmiş product getirir
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {  
                return filter == null ? //null olup olmadığını kontrol ediyoruz
                    context.Set<Product>().ToList() : //filter null ise yani herhangi bir filtre gerekmiyorsa bütün productları getir
                    context.Set<Product>().Where(filter).Where(filter).ToList(); //filtre null değilse burası çalışır


            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
