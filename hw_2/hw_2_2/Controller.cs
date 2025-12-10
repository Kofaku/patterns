using Microsoft.AspNetCore.Mvc;

namespace hw_2_2
{
    [ApiController]
    [Route("[controller]")]
    public class SomeEntityController : ControllerBase
    {
        [HttpGet("GetOne/{id}")]
        public IActionResult GetOne(Guid id)
        {
            var entity = Storage.Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpGet("GetMany")]
        public IActionResult GetMany()
        {
            return Ok(Storage.Entities);
        }

        [HttpGet("GetByFilter")]
        public IActionResult GetByFilter([FromQuery] Status? status)
        {
            IEnumerable<SomeEntity> result = Storage.Entities;
            if (status.HasValue)
            {
                result = result.Where(e => e.Status == status.Value);
            }
            return Ok(result.ToList());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] SomeEntity entity)
        {
            entity.Id = Guid.NewGuid();
            Storage.Entities.Add(entity);
            return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] SomeEntity entity)
        {
            var existing = Storage.Entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing == null) return NotFound();

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.Status = entity.Status;
            return Ok(existing);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = Storage.Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();

            Storage.Entities.Remove(entity);
            return NoContent();
        }

        [HttpPost("DeleteMany")]
        public IActionResult DeleteMany([FromBody] List<Guid> ids)
        {
            int removed = Storage.Entities.RemoveAll(e => ids.Contains(e.Id));
            return Ok($"Removed {removed} entities");
        }

        [HttpGet("Print/{id}")]
        public IActionResult Print(Guid id)
        {
            var entity = Storage.Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();

            string document = $"=== PRINT DOCUMENT ===\n" +
                             $"ID: {entity.Id}\n" +
                             $"Name: {entity.Name}\n" +
                             $"Description: {entity.Description}\n" +
                             $"Status: {entity.Status}\n" +
                             $"Printed: {DateTime.Now}";

            return Content(document, "text/plain");
        }

        [HttpPost("PrintMany")]
        public IActionResult PrintMany([FromBody] List<Guid> ids)
        {
            var entities = Storage.Entities.Where(e => ids.Contains(e.Id)).ToList();
            if (!entities.Any()) return NotFound();

            string document = $"=== PRINT DOCUMENT - MULTIPLE ===\n";
            foreach (var entity in entities)
            {
                document += $"\n--- Entity: {entity.Name} ---\n" +
                           $"ID: {entity.Id}\n" +
                           $"Description: {entity.Description}\n" +
                           $"Status: {entity.Status}\n";
            }
            document += $"\nTotal: {entities.Count} entities\n";
            document += $"Printed: {DateTime.Now}";

            return Content(document, "text/plain");
        }

        [HttpPost("SetStatus/{id}")]
        public IActionResult SetStatus(Guid id, [FromQuery] Status status)
        {
            var entity = Storage.Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null) return NotFound();

            entity.Status = status;
            return Ok(entity);
        }

        [HttpPost("Deactivate/{id}")]
        public IActionResult Deactivate(Guid id)
        {
            return SetStatus(id, Status.Inactive);
        }

        [HttpPost("Activate/{id}")]
        public IActionResult Activate(Guid id)
        {
            return SetStatus(id, Status.Active);
        }
    }
}
