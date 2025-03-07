﻿using Microsoft.EntityFrameworkCore;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PostDbContext _postDbContext;

        public GenericRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _postDbContext.Set<T>().AddAsync(entity);
            await _postDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> CreateRange(List<T> entities)
        {
            _postDbContext.Set<T>().AddRange(entities);
            return await _postDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            _postDbContext.Set<T>().Remove(entity);
            return await _postDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(List<T> entities)
        {
            _postDbContext.Set<T>().RemoveRange(entities);
            return await _postDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsEntity(string id)
        {
            return await _postDbContext.Set<T>().AnyAsync(x => EF.Property<string>(x, "Id") == id);
        }

        public async Task<List<T>> GetAll()
        {
            List<T> result = await _postDbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T?> GetById(string id)
        {
            return await _postDbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Id") == id) ?? null;
        }

        public async Task<T> Update(T entity)
        {
            var reponse = _postDbContext.Set<T>().Update(entity);
            var result = await _postDbContext.SaveChangesAsync();
            if (result == 1)
                return reponse.Entity;
            return null;
        }
    }
}