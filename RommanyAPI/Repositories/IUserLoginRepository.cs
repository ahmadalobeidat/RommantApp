namespace RommanyAPI;

public interface IUserLoginRepository
{
  Task<UserLogin> GetUserLoginByEmail(string email);
}
