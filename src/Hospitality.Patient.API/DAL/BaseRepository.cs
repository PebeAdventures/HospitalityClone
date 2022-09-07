namespace Hospitality.Patient.API.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PatientContext _context;

        public BaseRepository(PatientContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }
    }
}
