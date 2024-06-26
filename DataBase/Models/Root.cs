using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YG.Server.UserDataStorage.DataBase.Models;

public class Root
{
    [Key]
    public string Id { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;

    public List<Field> Fields { get; set; } = [];
}
