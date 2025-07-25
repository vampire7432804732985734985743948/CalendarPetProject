﻿using CalendarPetProject.CalendarDBContext;
using Microsoft.EntityFrameworkCore;
using CalendarPetProject.Data;

namespace CalendarPetProject.CalendarDBContext.DataBaseOperationService
{
    public class DataWriter<T> : IDataWriter<T> where T : class
    {
        private readonly AppDbContext _context;

        public DataWriter(AppDbContext context)
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
            if (entity != null)
            { 
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
