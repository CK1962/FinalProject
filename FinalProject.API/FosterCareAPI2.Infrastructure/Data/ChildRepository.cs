using FosterCareAPI2.Core.Models;
using FosterCareAPI2.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI2.Infrastructure.Data
{
    public class ChildRepository : IChildRepository
    {
        private readonly FosterAPIDbContext _dbContext;

        public ChildRepository(FosterAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Child> GetAll()
        {
            return _dbContext.Children
                 .Include(c => c.Home)
                //  .Include(c => c.Appointments)
                .ToList();
        }


        public Child Get(int id)
        {
            return _dbContext.Children
                  .Include(c => c.Home)
                 //  .Include(c => c.Appointments)
                 .SingleOrDefault(c => c.Id == id);
        }

        public Child Add(Child child)
        {
            _dbContext.Children.Add(child);
            _dbContext.SaveChanges();
            return child;
        }

        public Child Update(Child updatedChild)
        {
            var currentChild = _dbContext.Children.Find(updatedChild.Id);
            if (currentChild == null) return null;
            _dbContext.Entry(currentChild)
                .CurrentValues
                .SetValues(updatedChild);

            _dbContext.Children.Update(currentChild);
            _dbContext.SaveChanges();
            return currentChild;
        }

        public void Remove(int id)
        {
            var childToDelete = Get(id);

            // TODO: remove blog
            _dbContext.Children.Remove(childToDelete);
            _dbContext.SaveChanges();
        }
    }
}
