﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public delegate void NewConnectDelegate(string request, Socket socket);
}
