using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console
{
    public class LoggerServer : ILoggerServer
    {
        public void Error(object text)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            Write("ERROR", text);
            System.Console.ResetColor();
        }
        private void Write(string type, object text)
        {
            System.Console.WriteLine($"({DateTime.Now.ToString("HH:mm:ss")}) [{type}]: {text}");
        }

        public void Info(object text)
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            Write("INFO", text);
            System.Console.ResetColor();
        }

        public void Trace(object text)
        {
            Write("TRACE", text);
        }

        public void War(object text)
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            Write("WARNING", text);
            System.Console.ResetColor();
        }

        public void Shell(object text)
        {
            Write("SHELL", text);
        }
    }
}
