using CalendarPetProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public class UserDataOperator
    {
        private DbContext _dbContext;
        public UserDataOperator(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UploadInformation<T>(WebApplication app, T entity) where T : class
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            DataWriter<T> writer = new(context);
            writer.AddEntity(entity);
        }

    }
}
