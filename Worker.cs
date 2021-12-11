using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace advent_of_code_2021
{
    public class Worker
    {
        public Worker() {

        }

        public void SayHello()
        {
            System.Console.WriteLine("Fucking hello");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}