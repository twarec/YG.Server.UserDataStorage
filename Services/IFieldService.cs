using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Services;

public interface IFieldService
{
    public Task<Field?> GetAsync(int id);
    public Task<Field?> GetFromRootAsync(string rootId, string key);

    public Task<IEnumerable<Field>> GetAllAsync();
    public Task<IEnumerable<Field>> GetRangeAsync(int offset, int count);
    public Task<IEnumerable<Field>> GetAllAsync(string key);
    public Task<IEnumerable<Field>> GetRangeAsync(int offset, int count, string key);
    public Task<IEnumerable<Field>> GetAllFromRootAsync(string rootId);
    public Task<IEnumerable<Field>> GetRangeFromRootAsync(int offset, int count, string rootId);

    public Task<Field?> SetAsync(int id, string value);
    public Task<Field?> SetAsync(string rootId, string key, string value);

    public Task<Field?> CreateAsync(string rootId, string key, string value);
}
