using Reface.AppStarter.Attributes;
using System;
using TestCacheInThreads.Services;

namespace TestCacheInThreads
{
    public interface ITask
    {
        void Do();
    }

    [Component]
    public class Task : ITask
    {
        private readonly IService service;
        private static readonly Random random = new Random();

        public Task(IService service)
        {
            this.service = service;
        }

        public void Do()
        {
            int i = random.Next(3);
            int j = random.Next(3);
            if (i == 0)
            {
                this.service.GetByIdAndCleanWithValues(j);
            }
            else if (i == 1)
            {
                this.service.UpdateIAndCleanByI(j);
            }
            else
            {
                this.service.ClearAll();
            }
        }
    }
}
