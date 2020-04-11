using Reface.AppStarter.Attributes;
using System;
using System.Threading;

namespace TestCacheInThreads.Services
{
    public interface IService
    {
        int GetByIdAndCleanWithValues(int i);

        void UpdateIAndCleanByI(int i);

        void ClearAll();
    }

    [Component]
    public class Service : IService
    {

        [CleanCache("Values")]
        public void ClearAll()
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] ClearAll");
            ValueSeq.Next();
        }

        [Cache("Value_{0}")]
        [CleanWith("Values")]
        public int GetByIdAndCleanWithValues(int i)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] GetByIdAndCleanWithValues({i})");
            return ValueSeq.Next();
        }

        [CleanCache("Value_{0}")]
        public void UpdateIAndCleanByI(int i)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] UpdateIAndCleanByI({i})");
            ValueSeq.Next();
        }
    }
}
