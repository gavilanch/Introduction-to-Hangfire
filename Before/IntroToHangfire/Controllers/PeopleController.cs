using IntroToHangfire.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntroToHangfire.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PeopleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(string personName)
        {
            Console.WriteLine($"Adding person {personName}");
            var person = new Person { Name = personName };
            context.Add(person);
            await Task.Delay(5000);
            await context.SaveChangesAsync();
            Console.WriteLine($"Added the person {personName}");
            return Ok();
        }
    }
}
