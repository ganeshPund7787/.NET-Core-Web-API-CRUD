using Database_Connection_Practice.DTOs;

namespace Database_Connection_Practice.Services
{
    public interface IToDoService
    {
        Task<List<GetToDoResponse>> GetAllToDosAsync();

        Task<GetToDoResponse> GetToDoById(int id);

        Task<GetToDoResponse> CreateToDoAsync(CreateToDoRequest request);

        Task<bool> UpdateToDoAsync(int id, UpdateToDoRequest request);

        Task<bool> DeleteToDoAsync(int id);
    }
}
