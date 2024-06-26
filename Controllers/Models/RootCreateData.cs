using System.ComponentModel.DataAnnotations;
using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Controllers.Models;

public class RootCreateData
{
    [Required]
    public string Id { get; set; } = string.Empty;
    public List<FieldCreateData> Fields { get; set; } = [];

    public Root ToDataBase()
    {
        return new Root
        {
            Id = Id,
            Fields = Fields.Select(_ => _.ToDataBase()).ToList(),
        };
    }
}
