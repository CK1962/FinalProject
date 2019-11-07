using FosterCareAPI2.Core.Models;
using System.Collections.Generic;

namespace FosterCareAPI2.Core.Services
{
    public interface IChildService
    {
        Child Add(Child newChild);
        Child Update(Child updatedChild);
        Child Get(int id);
        IEnumerable<Child> GetAll();
        void Remove(int id);
    }
}