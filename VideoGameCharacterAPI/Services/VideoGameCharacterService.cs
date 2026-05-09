using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Data;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services
{
    public class VideoGameCharacterService(AppDBContext context) : IVideoGameCharacterService
    {
        
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharacterAsync()
        {
            return await context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters.FindAsync(id);
            return result;
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
