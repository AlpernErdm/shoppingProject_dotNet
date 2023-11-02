using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase <TEntity,TContext>:IEntityRepository<TEntity> //TEntity=Color-Car-Brand vb, TContext ise bizim projede kullandıgımız veritabanı
        where TEntity :class ,IEntity ,new()
        where TContext :DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //using =IDisposable pattern implementation for c# using bittiği anda garbage collector belleği temizler
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//Bağlama yeri
                addedEntity.State = EntityState.Added;//İşlem yeri //State durum anlamına gelir ve metotları modified-added-deleted yani ekleme silme güncelleme
                context.SaveChanges(); //Kaydetme yeri//İşlemleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);//filtrelenmiş productı getirir SingleOrDefault sadece filtrelenmiş product getirir
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? //null olup olmadığını kontrol ediyoruz
                    context.Set<TEntity>().ToList() : //filter null ise yani herhangi bir filtre gerekmiyorsa bütün productları getir
                    context.Set<TEntity>().Where(filter).Where(filter).ToList(); //filtre null değilse burası çalışır


            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
