using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Contexts;
using API.Domain.Entities;
using API.Domain.Interfaces;

namespace API.Data.Repositories
{
    public class TaskRepository : BaseRepository,ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public void Save(Task entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Task entity)
        {
            _context.Tasks.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Task entity)
        {
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public Task GetById(Guid id)
        {
            return _context.Tasks.Find(id);
        }

        public ICollection<Task> List()
        {
            return _context.Tasks.ToList();
        }
    }
}