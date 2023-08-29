namespace RommanyAPI;

public interface IUserRepository
{
  bool IsUserExist(string email);
}
