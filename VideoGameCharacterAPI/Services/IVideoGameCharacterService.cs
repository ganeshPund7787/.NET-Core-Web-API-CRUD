using VideoGameCharacterAPI.DTOs;

namespace VideoGameCharacterAPI.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<GetCharacterResponse>> GetAllCharacterAsync();
        Task<GetCharacterResponse?> GetCharacterByIdAsync(int id);
        Task<bool> DeleteCharacterAsync(int id);
        Task<GetCharacterResponse> AddCharacterAsync(CreateCharacterRequest character);
        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);
    }
}

