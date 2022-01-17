using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearTypesController : ControllerBase
    {
        IGearTypeService _gearTypeService;

        public GearTypesController(IGearTypeService gearTypeService)
        {
            _gearTypeService = gearTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _gearTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _gearTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(GearType gearType)
        {
            var result = _gearTypeService.Add(gearType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GearType gearType)
        {
            var result = _gearTypeService.Delete(gearType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(GearType gearType)
        {
            var result = _gearTypeService.Update(gearType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
