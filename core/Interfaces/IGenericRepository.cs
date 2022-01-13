using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Specifications;

namespace core.Interfaces
{
    //this is generic interface 
    public interface IGenericRepository<T>  where T:BaseEntity//T her refer to the type
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> LisAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

          Task<int> CountAsync(ISpecification<T> spec);
    }
}