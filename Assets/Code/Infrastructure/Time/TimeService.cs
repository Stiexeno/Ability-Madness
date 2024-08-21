namespace AbilityMadness.Code.Infrastructure.TimeService
{
    public class TimeService : ITimeService
    {
        public void Resume()
        {
            UnityEngine.Time.timeScale = 1;
        }

        public void Pause()
        {
            UnityEngine.Time.timeScale = 0;
        }
    }
}
