using Microsoft.AspNetCore.Mvc;

namespace hw_2_2
{
    [ApiController]
    [Route("[controller]")]
    public class SomeImageEntityController : ControllerBase
    {
        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(Guid id)
        {
            var entity = Storage.Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();

            var imageEntity = new SomeImageEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                ImageUrl = $"https://picsum.photos/400/300?random={entity.Id.GetHashCode()}"
            };

            return Ok(imageEntity);
        }

        [HttpPost("SetImage")]
        public IActionResult SetImage([FromBody] SomeImageEntity entity)
        {
            var existing = Storage.Entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing == null) return NotFound();

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.Status = entity.Status;

            Console.WriteLine($"Image URL set for entity {entity.Id}: {entity.ImageUrl}");

            return Ok(entity);
        }

        [HttpGet("GetEntitiesByFilter")]
        public IActionResult GetEntitiesByFilter([FromQuery] Status? status)
        {
            IEnumerable<SomeEntity> result = Storage.Entities;
            if (status.HasValue)
            {
                result = result.Where(e => e.Status == status.Value);
            }

            var imageEntities = result.Select(e => new SomeImageEntity
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Status = e.Status,
                ImageUrl = $"https://example.com/images/{e.Id}.jpg"
            }).ToList();

            return Ok(imageEntities);
        }
    }
}
