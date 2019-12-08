using FosterCareAPI2.Core.Models;
using System.Collections.Generic;

namespace FosterCareAPI2.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IChildRepository _childRepository;

        public HouseService(IHouseRepository houseRepository, IChildRepository childRepository)
        {
            _houseRepository = houseRepository;
            _childRepository = childRepository;
        }
        public House Add(House newHouse)
        {
            return _houseRepository.Add(newHouse);
        }

        public House Get(int id)
        {
            return _houseRepository.Get(id);
        }

        public IEnumerable<House> GetAll()
        {
            return _houseRepository.GetAll();
        }

        public IEnumerable<House> GetChildHome(int childId)
        {
            return _houseRepository.GetChildHome(childId);
        }

        public void Remove(int id)
        {
            var house = this.Get(id);
            _houseRepository.Remove(id);
        }

        public House Update(House updatedHouse)
        {
            var originalHouse = Get(updatedHouse.Id);
            originalHouse.Name = updatedHouse.Name;
            originalHouse.City = updatedHouse.City;
            _houseRepository.Update(originalHouse);
            return originalHouse;
        }
    }
}