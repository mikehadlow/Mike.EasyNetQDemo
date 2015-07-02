using System;
using EasyNetQ;
using Mike.EasyNetQDemo.Messages;

namespace Mike.EasyNetQDemo.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<WordMessage>("word_subscriber", message => Console.WriteLine(message.Word));

                Console.WriteLine("Subscription Started. Hit any key quit");
                Console.ReadKey();
            }
        }
    }
}
