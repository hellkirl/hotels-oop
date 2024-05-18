using System.ComponentModel.DataAnnotations;

namespace hotels.Infrastructure.Persistence.Entities;

public class UserEntity
{
    [Key]
    public uint user_id { get; set; }
    public string login { get; set; }
    public string password_hash { get; set; }
}
