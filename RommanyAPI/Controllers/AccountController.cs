using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RommanyAPI.Interfaces;

namespace RommanyAPI;

[Route("api/[controller]")]
public class AccountController : BaseController<User>
{
    private readonly IRepository<User> _userRepository;
    private readonly IUserLoginRepository _userLoginRepo;
    private readonly IUserRepository _userRepo;
    private readonly IRepository<UserLogin> _userLoginRepository;

    private readonly ITokenService _tokenService ;

    public AccountController(IUserRepository userRepo,IUserLoginRepository userLoginRepo, IRepository<User> userRepository, IRepository<UserLogin> userLoginRepository, ITokenService tokenService) : base(userRepository)
    {
        _userRepository = userRepository;
        _userLoginRepository = userLoginRepository;
        _tokenService = tokenService;
        _userLoginRepo = userLoginRepo;
        _userRepo = userRepo;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserloginDTO>> Register(RegistrationDto registrationDto)
    {
        using var hmac = new HMACSHA512();

         var isUserExist =  _userRepo.IsUserExist(registrationDto.Email);

        if(isUserExist) throw new Exception("Email is Already exist ..");

        var user = new User(registrationDto.FirstName, registrationDto.LastName, registrationDto.Email, registrationDto.Birthdate);

        var userEntity = await _userRepository.Add(user);


        var PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationDto.Password));
        var PasswordSalt = hmac.Key;
        if (userEntity is null) throw new Exception("User Not Found");

        var userLogin = new UserLogin(userEntity.Email, PasswordHash, PasswordSalt, userEntity.Id, (int)Roles.User);
        await _userLoginRepository.Add(userLogin);

        return new UserloginDTO(){
            UserName =  user.Email ,
            Token =  _tokenService.CreateToken(userLogin)
        };
    }


    [HttpPost("Login")]
    [Authorize]
    public async Task<ActionResult<UserloginDTO>> Login(LoginDto loginDto)
    {
        var userLogin = await _userLoginRepo.GetUserLoginByEmail(loginDto.UserName);

        if (userLogin == null) return Unauthorized("Invalid UserName");

        using var hmac = new HMACSHA512(userLogin.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if(computedHash[i] != userLogin.PasswordHash[i]) 
            return Unauthorized("Invalid Password");
        }
        
        //TODO:here we can return the data we need.
        return new UserloginDTO(){
        UserName =  userLogin.UserName ,
        Token =  _tokenService.CreateToken(userLogin)
        };
    }
}



