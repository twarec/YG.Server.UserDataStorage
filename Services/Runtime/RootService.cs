using Microsoft.EntityFrameworkCore;
using YG.Server.UserDataStorage.DataBase;
using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Services.Runtime;

public class RootService(GeneralContext db) : IRootService
{
    public async Task<Root?> CreateAsync(Root root)
    {
        await db.AddAsync(root);
        await db.SaveChangesAsync();
        return root;
    }

    public async Task<IEnumerable<Root>> GetAllAsync()
    {
        return await db.Roots
            .Include(_ => _.Fields)
            .ToListAsync();
    }

    public async Task<Root?> GetAsync(int id)
    {
        return await db.Roots
            .Include(_ => _.Fields)
            .SingleOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<Root?> GetAsync(string key)
    {
        return await db.Roots
            .Include(_ => _.Fields)
            .SingleOrDefaultAsync(x => x.Key == key);
    }

    public async Task<IEnumerable<Root>> GetRangeAsync(int offset, int count)
    {
        return await db.Roots
            .Include(_ => _.Fields)
            .Skip(offset).Take(count).ToListAsync();
    }
}
