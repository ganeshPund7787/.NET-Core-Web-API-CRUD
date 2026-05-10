using VideoGameCharacterAPI.DTOs;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<GetCharacterResponse>> GetAllCharacterAsync();

        Task<GetCharacterResponse?> GetCharacterByIdAsync(int id);

        //Task<GetCharacterResponse> AddCharacterAsync(CreateCharacterRequest character);

        //Task<UpdateCharacterRequest> UpdateCharacterAsync(int id, Character character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<GetCharacterResponse> AddCharacterAsync(CreateCharacterRequest character);
        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);
    }
}

