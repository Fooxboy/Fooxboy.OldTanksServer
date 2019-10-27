using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console
{
    public interface IConsoleCommand
    {
        string Trigger { get; }
        void Execute(string[] words);
    }
}
