using System;
using FosterCareAPI2.Core.Models;
using FosterCareAPI2.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FosterCareAPI2.ApiModels;

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
                _houseService.Add(house);
                var newHouseModel = house.ToApiModel();
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
        public IActionResult Put(int id, [FromBody] House house)
        {
            try
            {
                return Ok(_houseService.Update(house).ToApiModel());
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