using FosterCareAPI2.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI2.ApiModels
{
    public static class ChildMappingExtensions
    {
        public static ChildModel ToApiModel(this Child child)
        {
            return new ChildModel
            {
                Id = child.Id,
                Name = child.Name,
                Dob = child.Dob,
                MoveInDate = child.MoveInDate,
                HouseId = child.House.Id,
                HouseName = child.House.Name
            };
        }

        public static Child ToDomainModel(this ChildModel childModel)
        {
            return new Child
            {
                Id = childModel.Id,
                Name = childModel.Name,
                Dob = childModel.Dob,
                MoveInDate = childModel.MoveInDate,
                HouseId = childModel.HouseId
            };
        }

        public static IEnumerable<ChildModel> ToApiModels(this IEnumerable<Child> Children)
        {
            return Children.Select(c => c.ToApiModel());
        }

        public static IEnumerable<Child> ToDomainModels(this IEnumerable<ChildModel> ChildModels)
        {
            return ChildModels.Select(c => c.ToDomainModel());
        }
    }
}