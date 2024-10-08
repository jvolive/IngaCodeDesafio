namespace IngaCode.Application.Interfaces;
public interface IService<T>
{
    Task AddAsync(T entity);
    Task DeleteAsync(string name);
}
