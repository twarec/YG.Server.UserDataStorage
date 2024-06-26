using Microsoft.EntityFrameworkCore;
using YG.Server.UserDataStorage.DataBase;
using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Services.Runtime;

public class FieldService(GeneralContext db) : IFieldService
{
    public async Task<Field?> CreateAsync(string rootId, string key, string value)
    {
        var result = new Field
        {
            Key = key,
            Value = value
        };
        var root = await db.Roots.SingleOrDefaultAsync(_ => _.Id == rootId);
        if(root != null)
        {
            root.Fields.Add(result);
            await db.SaveChangesAsync();
            return result;
        }
        return null;
    }

    public async Task<IEnumerable<Field>> GetAllAsync()
    {
        return await db.Fields.ToListAsync();
    }

    public async Task<IEnumerable<Field>> GetAllAsync(string key)
    {
        return await db.Fields
            .Where(_ => _.Key == key)
            .ToListAsync();
    }

    public async Task<IEnumerable<Field>> GetAllFromRootAsync(string rootId)
    {
        var user = await db.Roots
            .Include(x => x.Fields)
            .SingleOrDefaultAsync(_ => _.Id == rootId);
        return user?.Fields ?? [];
    }

    public async Task<Field?> GetAsync(int id)
    {
        return await db.Fields.SingleOrDefaultAsync(_ => _.Id == id);
    }

    public Task<Field?> GetFromRootAsync(string rootId, string key)
    {
        return db.Fields.SingleOrDefaultAsync(_ => _.RootId == rootId && _.Key == key);
    }

    public async Task<IEnumerable<Field>> GetRangeAsync(int offset, int count)
    {
        return await db.Fields
            .Skip(offset)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<Field>> GetRangeAsync(int offset, int count, string key)
    {
        return await db.Fields
            .Where(_ => _.Key == key)
            .Skip(offset)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<Field>> GetRangeFromRootAsync(int offset, int count, string rootId)
    {
        var user = await db.Roots
            .Include(x => x.Fields.Skip(offset).Take(count))
            .SingleOrDefaultAsync(_ => _.Id == rootId);
        return user?.Fields ?? [];
    }

    public async Task<Field?> SetAsync(int id, string value)
    {
        var result = await GetAsync(id);
        if (result != null)
        {
            result.Value = value;
            await db.SaveChangesAsync();
            return result;
        }
        return null;
    }

    public async Task<Field?> SetAsync(string rootId, string key, string value)
    {
        var result = await GetFromRootAsync(rootId, key);
        if (result != null)
        {
            result.Value = value;
            result.DateUpdate = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }
        return result;
    }
}
