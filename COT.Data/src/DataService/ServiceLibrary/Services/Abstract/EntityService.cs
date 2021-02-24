using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using CoreLibrary.Services;
using DataLibrary.Interfaces;
using DataLibrary.Service;

namespace ServiceLibrary.Services.Abstract
{
    public class EntityService<T>: DbService, IEntityService<T> where T: Entity
    {
        public EntityService(ICotDataContext ctx) : base(ctx)
        {
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            return QueryById<T>(id);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public Task<T> GetById(int id)
        {
            return GetById<T>(id);
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }

        public ServiceResult ClearAll()
        {
            return ClearAll<T>();
        }

        public bool Exists(int id)
        {
            return Exists<T>(id);
        }
    }
}
