using Hangfire;
using IntroToHangfire.Entities;
using IntroToHangfire.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroToHangfire.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IBackgroundJobClient backgroundJobClient;

        public PeopleController(ApplicationDbContext context, 
            IBackgroundJobClient backgroundJobClient)
        {
            this.context = context;
            this.backgroundJobClient = backgroundJobClient;
        }

        [HttpPost("create")]
        public ActionResult Create(string personName)
        {
            //backgroundJobClient.Enqueue(() => Console.WriteLine(personName));
            backgroundJobClient.Enqueue<IPeopleRepository>(repository => 
                repository.CreatePerson(personName));
            return Ok();
        }

        [HttpPost("schedule")]
        public ActionResult Schedule(string personName)
        {
            var jobId = backgroundJobClient.Schedule(() => 
                Console.WriteLine("The name is " + personName),
                TimeSpan.FromSeconds(5));

            backgroundJobClient.ContinueJobWith(jobId, 
                () => Console.WriteLine($"The job {jobId} has finished"));

            return Ok();
        }

        //public async Task CreatePerson(string personName)
        //{
        //    Console.WriteLine($"Adding person {personName}");
        //    var person = new Person { Name = personName };
        //    context.Add(person);
        //    await Task.Delay(5000);
        //    await context.SaveChangesAsync();
        //    Console.WriteLine($"Added the person {personName}");
        //}
    }
}
