using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class UserInfoEntity
{
    [Key]
    public uint user_info_id { get; set; }
    public uint user_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string passport { get; set; }
    public DateTime birthday { get; set; }
}