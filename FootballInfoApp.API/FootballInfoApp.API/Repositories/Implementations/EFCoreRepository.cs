using System;
using AutoMapper;
using System.Linq;
using FootballInfoApp.Domain;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FootballInfoApp.API.Infrastructure.Models;
using FootballInfoApp.API.Repositories.Interfaces;
using FootballInfoApp.API.Infrastructure.Extensions;

namespace FootballInfoApp.API.Repositories.Implementations
{
     public class EFCoreRepository : IRepository
     {
          private readonly FootballInfoAppDbContext _soccerInfoAppDbContext;
          private readonly IMapper _mapper;

          public EFCoreRepository(FootballInfoAppDbContext onlineBookShopDbContext, IMapper mapper)
          {
               _soccerInfoAppDbContext = onlineBookShopDbContext;
               _mapper = mapper;
          }

          public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
          {
               return await _soccerInfoAppDbContext.Set<TEntity>().ToListAsync();
          }

          public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
          {
               return await _soccerInfoAppDbContext.FindAsync<TEntity>(id);
          }

          public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
          {
               var query = IncludeProperties(includeProperties);
               return await query.FirstOrDefaultAsync(entity => entity.Id == id);
          }

          public async Task<bool> SaveAll()
          {
               return await _soccerInfoAppDbContext.SaveChangesAsync() >= 0;
          }

          public async Task<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity
          {
               _soccerInfoAppDbContext.Set<TEntity>().Add(entity);
               await _soccerInfoAppDbContext.SaveChangesAsync();
               return entity;
          }

          public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : BaseEntity
          {
               // In case entity is not tracked
               _soccerInfoAppDbContext.Entry(entity).State = EntityState.Modified;
               await _soccerInfoAppDbContext.SaveChangesAsync();
               return entity;
          }

          public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
          {
               var entity = await _soccerInfoAppDbContext.Set<TEntity>().FindAsync(id);
               if (entity == null)
               {
                    throw new Exception($"Object of type {typeof(TEntity)} with id { id } not found");
               }

               _soccerInfoAppDbContext.Set<TEntity>().Remove(entity);
               await _soccerInfoAppDbContext.SaveChangesAsync();

               return entity;
          }

          public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
                                                                                                      where TDto : class
          {
               return await _soccerInfoAppDbContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
          }

          private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
          {
               IQueryable<TEntity> entities = _soccerInfoAppDbContext.Set<TEntity>();
               foreach (var includeProperty in includeProperties)
               {
                    entities = entities.Include(includeProperty);
               }
               return entities;
          }
     }
}
