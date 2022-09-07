namespace Hospitality.Patient.API.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);
    }
}
