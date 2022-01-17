using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBodyTypesController : ControllerBase
    {
        ICarBodyTypeService _carBodyTypeService;

        public CarBodyTypesController(ICarBodyTypeService carBodyTypeService)
        {
            _carBodyTypeService = carBodyTypeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carBodyTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carBodyTypeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CarBodyType carBodyType)
        {
            var result = _carBodyTypeService.Add(carBodyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarBodyType carBodyType)
        {
            var result = _carBodyTypeService.Delete(carBodyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarBodyType carBodyType)
        {
            var result = _carBodyTypeService.Update(carBodyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
