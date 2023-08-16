using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository_Pattern.Data;
using Repository_Pattern.DTO;
using Repository_Pattern.Models;
using System.Linq.Expressions;

namespace Repository_Pattern.Repository
{
    public class BaseRepo<t> : IBaseRepo<t> where t : class
    {
        protected ApplicationDbContext context;

        public BaseRepo(ApplicationDbContext _applicationDbContext)
        {
            context = _applicationDbContext;
        }

        public async Task<t> GetById(int id)
        {
            return await context.Set<t>().FindAsync(id);
        }
        public async Task<List<t>> GetAll()
        {
            return await context.Set<t>().ToListAsync();
        }
        public async Task<t> find(Expression<Func<t, bool>> match)
        {
            return await context.Set<t>().FirstOrDefaultAsync(match);
        }
        public async Task<t> FindInclude(Expression<Func<t, bool>> match, string[]Include=null)
        {
            IQueryable<t> obj = context.Set<t>();
            if (Include != null)
            {
                foreach (var item in Include)
                {
                    obj = obj.Include(item);
                }
            }
            return await obj.FirstOrDefaultAsync(match);
        }
        public async Task<IEnumerable<t>> FindAll(Expression<Func<t, bool>> match, string[] Include = null)
        {
            IQueryable<t> obj = context.Set<t>();
            if (Include != null)
            {
                foreach (var item in Include)
                {
                    obj = obj.Include(item);
                }
            }
            return await obj.Where(match).ToListAsync();
        }
        public async Task<t> Add(t entity)
        {
            context.Set<t>().Add(entity);
            context.SaveChangesAsync();
            return entity;
        }
        public async Task<t> Update(t entity)
        {
            context.Set<t>().Update(entity);
            context.SaveChanges();
            return entity;
        }
        public void Delete(t entity)
        {
            context.Set<t>().Remove(entity);
            context.SaveChanges();

        }

       
    }
}

