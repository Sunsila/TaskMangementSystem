using Dapper.Data.Models.Domain;

namespace Dapper.Data.Repository
{
    public interface ITaskRepository
    {
        Task<bool> AddTaskAsync(TaskDetailRequestModel taskreq);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<TaskDetailRequestModel>> GetAllTaskAsync();
        Task<TaskDetailRequestModel?> GetTaskByIdAsync(int id);
        Task<bool> UpdateTaskAsync(TaskDetailRequestModel taskreq);
    }
}