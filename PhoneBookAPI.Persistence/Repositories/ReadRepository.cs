﻿using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Domain.Entities.Common;
using PhoneBookAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly PhoneBookAPIDbContext _context;
        public ReadRepository(PhoneBookAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traking = true)
        {
            var query = Table.Where(method);
            if (!traking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<T> GetByIdAsync(string id, bool traking = true)
        //=>await Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
        //  => await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
