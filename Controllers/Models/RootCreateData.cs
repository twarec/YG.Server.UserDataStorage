using System.ComponentModel.DataAnnotations;
using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Controllers.Models
{
    public class RootCreateData
    {
        [Required]
        public string Key { get; set; } = string.Empty;
        public List<FieldCreateData> Fields { get; set; } = [];

        public Root ToDataBase()
        {
            return new Root
            {
                Key = Key,
                Fields = Fields.Select(_ => _.ToDataBase()).ToList(),
            };
        }
    }
}
