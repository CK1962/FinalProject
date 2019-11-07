using FosterCareAPI2.Core.Models;
using System.Collections.Generic;

namespace FosterCareAPI2.Core.Services
{
    public interface IHouseService
    {
        House Add(House newHouse);
        House Update(House updatedHouse);
        House Get(int id);
        IEnumerable<House> GetAll();
        IEnumerable<House> GetChildHome(int childId);
        void Remove(int id);
    }
}