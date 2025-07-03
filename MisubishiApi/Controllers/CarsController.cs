using Microsoft.AspNetCore.Mvc;
using Misubishi.BLL.Services;
using Misubishi.DAL.DTO;

namespace MisubishiApi.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly CarService _service;

        public CarsController(CarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _service.GetById(id);
            if (car == null) return NotFound(new { message = "Car not found" });
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCarDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                return BadRequest(new { error = "Name is required" });

            var created = _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateCarDto dto)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound(new { message = "Car not found" });

            _service.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound(new { message = "Car not found" });

            _service.Delete(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string name = "", int? categoryId = null)
        {
            var result = _service.Search(name, categoryId);
            return Ok(result);
        }
    }
}
