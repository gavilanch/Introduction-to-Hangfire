namespace IntroToHangfire.Services
{
    public interface ITimeService
    {
        void PrintNow();
    }

    public class TimeService: ITimeService
    {
        private readonly ILogger<TimeService> logger;

        public TimeService(ILogger<TimeService> logger)
        {
            this.logger = logger;
        }

        public void PrintNow()
        {
            logger.LogInformation(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        }
    }
}
