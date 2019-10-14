using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public delegate string NewConnectDelegate(string request, Socket socket);
}
