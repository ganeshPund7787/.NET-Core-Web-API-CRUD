using Database_Connection_Practice.DataBase;
using Database_Connection_Practice.DTOs;
using Database_Connection_Practice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Database_Connection_Practice.Services
{
    public class ToDOService(AppDbContext context) : IToDoService
    {
        public async Task<GetToDoResponse> CreateToDoAsync(CreateToDoRequest request)
        {
            var newTodo = new ToDo
            {
                Title = request.Title,
                Description = request.Description
            };

                context.ToDos.Add(newTodo);
                await context.SaveChangesAsync();

            return new GetToDoResponse
            {
                Id = newTodo.Id,
                Title = newTodo.Title,
                Description = newTodo.Description
            };
        }

        public async Task<bool> DeleteToDoAsync(int id)
        {
            var deletedTodo = await context.ToDos.FindAsync(id);
            if (deletedTodo is null) {
                return false;
            }

            context.Remove(deletedTodo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetToDoResponse>> GetAllToDosAsync()
        {
            return await context.ToDos
                .Select(c => new GetToDoResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<GetToDoResponse> GetToDoById(int id)
        {
            var existsingTodo = await context.ToDos.
                                    Where(c => c.Id==id).
                                    Select(c => new GetToDoResponse
                                    { 
                                        Id=c.Id,
                                        Title=c.Title,
                                        Description=c.Description
                                    }).FirstOrDefaultAsync();
            
            return existsingTodo;
        }

        public async Task<bool> UpdateToDoAsync(int id, UpdateToDoRequest request)
        {
            var existingUser = await context.ToDos.FindAsync(id);
            if (existingUser is null) {
                return false;
            }

            existingUser.Title = request.Title;
            existingUser.Description = request.Description;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
