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
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }
        // GET api/child
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var child = _childService.GetAll();
                var childModels = child.Select(c => c.ToApiModel());
                return Ok(childModels);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetChild", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/child/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var child = _childService.Get(id);
                var childModels = child.ToApiModel();
                return Ok(childModels);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("GetChild", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/child
        [HttpPost]
        public IActionResult Post([FromBody] ChildModel childModel)
        {
            try
            {
               var child = childModel.ToDomainModel();
                _childService.Add(child);
                var newChildModel = child.ToApiModel();
                return Ok(newChildModel);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddChild", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/child/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Child child)
        {
            try
            {
                return Ok(_childService.Update(child).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateChild", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _childService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteChild", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}