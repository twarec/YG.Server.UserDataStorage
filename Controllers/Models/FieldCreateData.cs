using YG.Server.UserDataStorage.DataBase.Models;

namespace YG.Server.UserDataStorage.Controllers.Models
{
    public class FieldCreateData
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public Field ToDataBase()
        {
            return new Field
            {
                Key = Key,
                Value = Value
            };
        }
    }
}
