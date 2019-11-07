using System;
using System.Collections.Generic;
using FosterCareAPI2.Core.Models;

namespace FosterCareAPI2.Core.Services
{
    public interface IHouseRepository
    {
        House Add(House House);
        House Update(House House);
        House Get(int id);
        IEnumerable<House> GetAll();
        void Remove(int id);
        IEnumerable<House> GetChildHome(int childId);
    }
}

