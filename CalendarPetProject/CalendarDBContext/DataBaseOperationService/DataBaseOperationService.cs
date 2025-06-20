using System;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public class DataBaseOperationService
    {
        private readonly ApplicationDBContext? _dbContext = null;

        public DataBaseOperationService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public DataBaseOperationService()
        {
                
        }
        public void UploadInformation<T>(WebApplication app, T entity) where T : class
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            DataWriter<T> writer = new(context);
            writer.AddEntity(entity);
        }
    }
}
