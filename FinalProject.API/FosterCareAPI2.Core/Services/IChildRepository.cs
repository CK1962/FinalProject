using FosterCareAPI2.Core.Models;
using System.Collections.Generic;

namespace FosterCareAPI2.Core.Services
{
    public interface IChildRepository
    {
        Child Add(Child Child);
        Child Update(Child Child);
        Child Get(int id);
        IEnumerable<Child> GetAll();
        void Remove(int id);
    }
}