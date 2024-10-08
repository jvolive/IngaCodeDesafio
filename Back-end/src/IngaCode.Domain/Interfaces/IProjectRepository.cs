using IngaCode.Domain.Entities;

namespace IngaCode.Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetByNameAsync(string name);
        Task UpdateByNameAsync(Project entity, string oldName);
    }
}
