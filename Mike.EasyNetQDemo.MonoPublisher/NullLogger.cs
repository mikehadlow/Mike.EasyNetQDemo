using System;
using EasyNetQ;

namespace Mike.EasyNetQDemo
{
    public class NullLogger : IEasyNetQLogger
    {
        public void DebugWrite(string format, params object[] args)
        {
            
        }

        public void InfoWrite(string format, params object[] args)
        {
            
        }

        public void ErrorWrite(string format, params object[] args)
        {
			Console.WriteLine(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            
        }
    }
}