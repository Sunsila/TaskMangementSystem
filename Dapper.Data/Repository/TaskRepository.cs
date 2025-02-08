using Dapper.Data.DataAccess;
using Dapper.Data.Models.Domain;

namespace Dapper.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ISQLdataAccess _db;

        public TaskRepository(ISQLdataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddTaskAsync(TaskDetailRequestModel taskreq)
        {
            try
            {
                await _db.SaveData("task.proc_addtask", new { taskreq.Title, taskreq.Description, taskreq.Status, taskreq.CreatedAt, taskreq.DueDate, taskreq.Priority });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTaskAsync(TaskDetailRequestModel taskreq)
        {
            try
            {

                await _db.SaveData("task.proc_updatetask", taskreq);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            try
            {
                await _db.SaveData("task.proc_deletetask", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TaskDetailRequestModel?> GetTaskByIdAsync(int id)
        {
            IEnumerable<TaskDetailRequestModel> result = await _db.GetData<TaskDetailRequestModel, dynamic>("task.proc_gettaskbyid", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<TaskDetailRequestModel>> GetAllTaskAsync()
        {
            string getalltaskdetails = "task.proc_gettask";
            return await _db.GetData<TaskDetailRequestModel, dynamic>(getalltaskdetails, new { });
        }

        public Task<bool> AddAsync(TaskDetailRequestModel taskreq)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDetailRequestModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TaskDetailRequestModel taskreq)
        {
            throw new NotImplementedException();
        }
    }
}
