using Microsoft.AspNetCore.Mvc;

namespace RommanyAPI;

    [ApiController]
    public class BaseController<T> : ControllerBase where T : class,IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var items = await _repository.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Add(T item)
        {
            await _repository.Add(item);
            // return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(T item)
        {
            await _repository.Update(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
