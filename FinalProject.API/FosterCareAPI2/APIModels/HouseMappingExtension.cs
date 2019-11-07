using FosterCareAPI2.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace FosterCareAPI2.ApiModels
{
    public static class HouseMappingExtensions
    {
        public static HouseModel ToApiModel(this House house)
        {
            return new HouseModel
            {
                Id = house.Id,
                Name = house.Name,
                City = house.City,
                Children = string.Join("; ", house.Children.Select(x => x.Name))
            };
        }

        public static House ToDomainModel(this HouseModel houseModel)
        {
            return new House
            {
                Id = houseModel.Id,
                Name = houseModel.Name,
                City = houseModel.City,
            };
        }

        public static IEnumerable<HouseModel> ToApiModels(this IEnumerable<House> Houses)
        {
            return Houses.Select(c => c.ToApiModel());
        }

        public static IEnumerable<House> ToDomainModels(this IEnumerable<HouseModel> HouseModels)
        {
            return HouseModels.Select(c => c.ToDomainModel());
        }
    }
}