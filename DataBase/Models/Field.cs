using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YG.Server.UserDataStorage.DataBase.Models;

[Index(nameof(Key))]
[Index(nameof(RootId), nameof(Key), IsUnique = true)]
public class Field
{
    [Key]
    public int Id { get; set; } = 0;

    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdate { get; set; } = DateTime.UtcNow;

    public string RootId { get; set; } = string.Empty;
}
