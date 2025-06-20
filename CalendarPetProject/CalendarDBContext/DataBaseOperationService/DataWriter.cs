using CalendarPetProject.CalendarDBContext.Tables;
using CalendarPetProject.CalendarDBContext;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public class DataWriter<T> : IDataWriter<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public DataWriter(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
