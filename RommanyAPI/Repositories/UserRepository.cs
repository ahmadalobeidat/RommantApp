using RommanyAPI.Store;

namespace RommanyAPI;

public class UserRepository : IUserRepository
{
    private readonly RommanyDBContext _dBContext;
    public UserRepository(RommanyDBContext dBContext)
    {
        _dBContext = dBContext;
    }
    public bool IsUserExist(string email)
    {
        var user = _dBContext.Users.SingleOrDefault(u => u.Email == email);
        return user is not null;
    }
}
