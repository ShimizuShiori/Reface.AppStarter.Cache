using Reface.AppStarter;
using Reface.AppStarter.AppContainers;
using System;
using System.Text;
using System.Threading;

namespace TestCacheInThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSetup appSetup = new AppSetup();
            var app = appSetup.Start(new TestAppModule());
            var container = app.GetAppContainer<IComponentContainer>();
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(new ThreadStart(() =>
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} Started");
                    for (int j = 0; j < 10; j++)
                    {
                        using (var scope = container.BeginScope($"TEST_{Thread.CurrentThread.Name}_{j}"))
                        {
                            var task = scope.CreateComponent<ITask>();
                            task.Do();
                        }
                    }
                }));
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < 10; k++)
                {
                    if (k == i) sb.Append(i.ToString());
                    else sb.Append(" ");
                }
                t.Name = sb.ToString();
                t.Start();
            }
            Console.ReadLine();
        }
    }
}
