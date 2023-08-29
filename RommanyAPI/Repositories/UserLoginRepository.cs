using RommanyAPI.Store;

namespace RommanyAPI;

public class UserLoginRepository : IUserLoginRepository
{
    private readonly RommanyDBContext _dBContext;
    public UserLoginRepository(RommanyDBContext dBContext)
    {
        _dBContext = dBContext;
    }


    public async Task<UserLogin> GetUserLoginByEmail(string email)
    {
        var userLogin =  _dBContext.UserLogin.SingleOrDefault(x => x.UserName == email); 
        if (userLogin is null) throw new ArgumentNullException(nameof(userLogin));
        await Task.CompletedTask;
        return userLogin;
    }
}
