namespace RommanyAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserLogin userLogin);
    }
}