using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YG.Server.UserDataStorage.DataBase.Models;

[Index(nameof(Key), IsUnique = true)]
public class Root
{
    [Key]
    public int Id { get; set; } = 0;

    public string Key { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;

    public List<Field> Fields { get; set; } = [];
}
