using System;
using System.Threading.Tasks;
using FootballInfoApp.Domain;
using System.Linq.Expressions;
using System.Collections.Generic;
using FootballInfoApp.API.Infrastructure.Models;

namespace FootballInfoApp.API.Repositories.Interfaces
{
     public interface IRepository
     {
          Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity;

          Task<List<TEntity>> GetAllWithInclude<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity;

          Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity;

          Task<bool> SaveAll();

          TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

          TEntity Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

          Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity;

          Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
                                                                                               where TDto : class;
     }
}
