using System;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Mike.EasyNetQDemo.Messages;

namespace Mike.EasyNetQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost", new NullLogger()))
            {
                Task.Factory.StartNew(() => Publish(bus));

                Console.WriteLine("Publisher Started, Hit any key to quit");
                Console.ReadKey();
            }
        }

        public static void Publish(IBus bus)
        {
            using(var channel = bus.OpenPublishChannel())
            {
                foreach (var word in WordLoader.LoadWords())
                {
                    var topic = word.Substring(0, 1);

                    Thread.Sleep(10);
                    channel.Publish(topic, new WordMessage{ Word = word });
                    Console.WriteLine("Published '{0}'", word);
                }
            }
        }
    }
}
