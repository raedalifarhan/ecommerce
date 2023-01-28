
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    // Inherite From BaseEntity Means:
    // Only Our Entities Can Be Used With Our Generic Repository
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}