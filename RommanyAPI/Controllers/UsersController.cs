using Microsoft.AspNetCore.Mvc;

namespace RommanyAPI;

[Route("api/[controller]")]
public class UsersController : BaseController<User>
{
    public UsersController(IRepository<User> repository) : base(repository)
    {
    }
}
