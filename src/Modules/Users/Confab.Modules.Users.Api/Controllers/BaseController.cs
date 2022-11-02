using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Users.Api.Controllers;

[ApiController]
[Route(UsersModule.BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{ 
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model);
    }
}   