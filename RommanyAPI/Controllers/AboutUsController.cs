using Microsoft.AspNetCore.Mvc;

namespace RommanyAPI;

[ApiController]
[Route("api/[controller]")]
public class AboutUsController : BaseController<AboutUs>
{
    public AboutUsController(IRepository<AboutUs> repository) : base(repository)
    {
    }
}
