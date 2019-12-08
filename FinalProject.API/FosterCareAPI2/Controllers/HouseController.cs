using FosterCareAPI2.ApiModels;
using FosterCareAPI2.Core.Models;
using FosterCareAPI2.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FosterCareAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        // GET api/House
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var house = _houseService.GetAll();
                var houseModels = house.Select(c => c.ToApiModel());
                return Ok(houseModels);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetHouse", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/House/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var house = _houseService.Get(id);
                var houseModels = house.ToApiModel();
                return Ok(houseModels);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("GetHouse", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/House
        [HttpPost]
        public IActionResult Post([FromBody] HouseModel houseModel)
        {
            try
            {
                var house = houseModel.ToDomainModel();
                var newHouse = _houseService.Add(house);
                var newHouseModel = newHouse.ToApiModel();
                return Ok(newHouseModel);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddHouse", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/House/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HouseModel houseModel)
        {
            try
            {
                var house = houseModel.ToDomainModel();
                var updatedHouse =_houseService.Update(house);
                var updatedHouseModel = updatedHouse.ToApiModel();
                return Ok(updatedHouseModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateHouse", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _houseService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteHouse", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}