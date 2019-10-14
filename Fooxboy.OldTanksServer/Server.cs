using Fooxboy.OldTanksServer.Core;
using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Server
    {
        private readonly ILoggerServer _logger;
        private readonly string _ip;
        private readonly int _port;
        private readonly RequestProccessor _proccessor;
        public static readonly List<IRequest> RequestsCommands = new List<IRequest>();
        public Server(ILoggerServer logger, string ip, int port)
        {
            this._logger = logger;
            this._ip = ip;
            this._port = port;
            this._proccessor = new RequestProccessor();
        }

        public void Start()
        {
            Console.WriteLine("Old Tanks Server 2019 by Fooxboy");
            _logger.Info("Запуск сервера...");
            var listener = new SocketConnectListener(_ip, _port, _logger);
            listener.NewConnectEvent += NewConnect;
            Server.RequestsCommands.Add(new Login());
        }

        private string NewConnect(string request, Socket socket)
        {
            var login = new Login();
            return login.Execute(request.Split(";").ToList());
        }
    }
}
