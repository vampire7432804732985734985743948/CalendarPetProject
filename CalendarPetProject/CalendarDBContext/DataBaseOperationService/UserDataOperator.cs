using CalendarPetProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public class UserDataOperator
    {
        public void UploadInformation<T>(WebApplication app, T entity) where T : class
        {
            if (entity != null && app != null)
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DataWriter<T> writer = new(context);
                writer.AddEntity(entity);
            }
        }

    }
}
