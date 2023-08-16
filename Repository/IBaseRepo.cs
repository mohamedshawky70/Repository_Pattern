using Microsoft.AspNetCore.Mvc;
using Repository_Pattern.Models;
using System.Linq.Expressions;

namespace Repository_Pattern.Repository
{
    public interface IBaseRepo<t> where t:class
    {
        Task<t> GetById(int id);
        Task<List<t>> GetAll();
        Task<t> find(Expression<Func<t, bool>> match);
        Task<t> FindInclude(Expression<Func<t, bool>> match, string[] Include = null);
        Task<IEnumerable<t>> FindAll(Expression<Func<t, bool>> match, string[] Include = null);
        Task<t> Add(t entity);
        Task<t> Update(t entity);
        void Delete(t entity);
        



    }
}