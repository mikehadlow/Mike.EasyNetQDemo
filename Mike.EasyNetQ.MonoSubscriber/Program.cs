using System;
using EasyNetQ;
using Mike.EasyNetQDemo.Messages;

namespace Mike.EasyNetQDemo.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var topic = args.Length > 0 ? args[0] : "#";

            using (var bus = RabbitHutch.CreateBus("host=localhost", new NullLogger()))
            {
                bus.Subscribe<WordMessage>("word_subscriber", topic, message => Console.WriteLine(message.Word));

                Console.WriteLine("Subscription Started. Hit any key quit");
                Console.ReadKey();
            }
        }
    }
}
