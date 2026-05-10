using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Data;
using VideoGameCharacterAPI.Models;
using VideoGameCharacterAPI.DTOs;

namespace VideoGameCharacterAPI.Services
{
    public class VideoGameCharacterService(AppDBContext context) : IVideoGameCharacterService
    {
        
        public async Task<GetCharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new GetCharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public Task AddCharacterAsync(object character)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);
            if (characterToDelete is null)
                return false;

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetCharacterResponse>> GetAllCharacterAsync()
        {
            return await context.Characters
                .Select(c => new GetCharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .ToListAsync(); 
        }

        public async Task<GetCharacterResponse> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters.
                        Where(c => c.Id==id)
                        .Select(c => new GetCharacterResponse
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Game = c.Game,
                            Role = c.Role
                        }) .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingUser = await context.Characters.FindAsync(id);
            if(existingUser is null)                
                return false;
            
            existingUser.Name=character.Name;
            existingUser.Game=character.Game;
            existingUser.Role=character.Role;
            
            await context.SaveChangesAsync();
            return true;
        }

        
    }
}
