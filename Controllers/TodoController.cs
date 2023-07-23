using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers;

[ApiController]
[Route("/todos")]
public class TodoController: ControllerBase {

    [HttpGet]
    public IActionResult Hello() {
        return Ok(new {message="Hello!"});
    }
    

}