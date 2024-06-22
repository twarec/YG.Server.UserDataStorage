using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Services;

public interface IRootService
{
    public Task<Root?> CreateAsync(Root root);

    public Task<Root?> GetAsync(int id);
    public Task<Root?> GetAsync(string key);

    public Task<IEnumerable<Root>> GetAllAsync();
    public Task<IEnumerable<Root>> GetRangeAsync(int offset, int count);
}
