using FosterCareAPI2.Core.Models;
using FosterCareAPI2.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI2.Infrastructure.Data
{
    public class HouseRepository : IHouseRepository
    {
        private readonly FosterAPIDbContext _dbContext;

        public HouseRepository(FosterAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<House> GetAll()
        {
            return _dbContext.Home
            .Include(c => c.Children)
            .ToList();
        }

        public House Get(int id)
        {
            return _dbContext.Home
            .Include(c => c.Children)
            .SingleOrDefault(c => c.Id == id);
        }

        public House Add(House house)
        {
            _dbContext.Home.Add(house);
            _dbContext.SaveChanges();
            return house;
        }

        public House Update(House updatedHouse)
        {
            var currentHouse = _dbContext.Home.Find(updatedHouse.Id);
            if (currentHouse == null) return null;
            _dbContext.Entry(currentHouse)
                .CurrentValues
                .SetValues(updatedHouse);

            _dbContext.Home.Update(currentHouse);
            _dbContext.SaveChanges();
            return currentHouse;
        }

        public void Remove(int id)
        {
            var houseToDelete = Get(id);

            _dbContext.Home.Remove(houseToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<House> GetChildHome(int childId)
        {
            var GetChildHome = Get(childId);
            return _dbContext.Home
           .Include(c => c.Children)
           .ToList();
        }
    }
}