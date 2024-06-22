using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Services;

public interface IFieldService
{
    public Task<Field?> GetAsync(int id);
    public Task<Field?> GetFromRootAsync(int rootId, string key);
    public Task<Field?> GetFromRootAsync(string rootKey, string key);

    public Task<IEnumerable<Field>> GetAllAsync();
    public Task<IEnumerable<Field>> GetRangeAsync(int offset, int count);
    public Task<IEnumerable<Field>> GetAllAsync(string key);
    public Task<IEnumerable<Field>> GetRangeAsync(int offset, int count, string key);
    public Task<IEnumerable<Field>> GetAllFromRootAsync(int rootId);
    public Task<IEnumerable<Field>> GetAllFromRootAsync(string rootKey);
    public Task<IEnumerable<Field>> GetRangeFromRootAsync(int offset, int count, int rootId);
    public Task<IEnumerable<Field>> GetRangeFromRootAsync(int offset, int count, string rootKey);

    public Task<Field?> SetAsync(int id, string value);
    public Task<Field?> SetAsync(int rootId, string key, string value);
    public Task<Field?> SetAsync(string rootKey, string key, string value);

    public Task<Field?> CreateAsync(int rootId, string key, string value);
    public Task<Field?> CreateAsync(string rootKey, string key, string value);
}
