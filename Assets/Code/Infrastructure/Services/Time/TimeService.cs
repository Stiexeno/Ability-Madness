using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.TimeService
{
    public class TimeService : ITimeService
    {
        public void Resume()
        {
            Time.timeScale = 1;
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }
    }
}
