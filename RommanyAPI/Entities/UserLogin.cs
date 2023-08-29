namespace RommanyAPI;

public class UserLogin :IEntity
{
    public UserLogin()
    {
    }
    public UserLogin(string userName, byte[] passwordHash, byte[] passwordSalt, int userId, int? role)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserId = userId;
        RoleId = role;
    }
    public int Id { get; set; }
    public string UserName { get; set; } //Email
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int? RoleId { get; set; }
}
