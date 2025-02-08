
namespace Dapper.Data.DataAccess
{
    public interface ISQLdataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "conn");
        Task SaveData<T>(string spName, T parameters, string connectionId = "conn");
    }
}