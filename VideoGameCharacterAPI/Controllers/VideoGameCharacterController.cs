using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterAPI.DTOs;
using VideoGameCharacterAPI.Models;
using VideoGameCharacterAPI.Services;

namespace VideoGameCharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterController(IVideoGameCharacterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<GetCharacterResponse>>> GetCharacters()
            => Ok(await service.GetAllCharacterAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            return character is null ? NotFound("Character with given Id Not Found") : Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<GetCharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var newCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.Id }, newCharacter);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            var updated = await service.UpdateCharacterAsync(id, character);
            return updated ? NoContent() : NotFound("Character with given Id Not Found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            return deleted ? NoContent() : NotFound("Character with given Id Not Found");
        }
 
    }
}

