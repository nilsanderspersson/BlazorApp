using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("/api/project/basic")]
        public IActionResult Basic()
        {
            return Ok("API FÖR PROJECT FRÅN JEEVES");
        }

        [HttpGet]
        [Route("/api/project/")]
        public IActionResult Get()
        {
            var items = Cache.GetProjects();
            return Ok(items);
        }
    }
}
