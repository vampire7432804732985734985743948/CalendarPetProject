using System;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public interface IDataWriter<T>
    {
        void AddEntity(T entity);
        Task AddEntityAsync(T entity);
    }
}
