using IntroToHangfire.Entities;

namespace IntroToHangfire.Services
{

    public interface IPeopleRepository
    {
        Task CreatePerson(string personName);
    }

    public class PeopleRepository: IPeopleRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<PeopleRepository> logger;

        public PeopleRepository(ApplicationDbContext context, ILogger<PeopleRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task CreatePerson(string personName)
        {
            logger.LogInformation($"Adding person {personName}");
            var person = new Person { Name = personName };
            context.Add(person);
            await Task.Delay(5000);
            await context.SaveChangesAsync();
            logger.LogInformation($"Added the person {personName}");
        }
    }
}
