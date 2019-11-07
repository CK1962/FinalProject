using System;
using FosterCareAPI2.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI2.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IChildRepository _childRepository;
        //private readonly IAppointmentRepository _appointmentRepository;

        // TODO: inject IHouseRepository
        public HouseService(IHouseRepository houseRepository, IChildRepository childRepository)
        {
            _houseRepository = houseRepository;
            _childRepository = childRepository;
           // _appointmentRepository = appointmentRepository;
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
            return _houseRepository.Update(updatedHouse);
        }
    }
}
