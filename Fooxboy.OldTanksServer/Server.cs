using Fooxboy.OldTanksServer.Core;
using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.OldTanksServer
{
    public class Server
    {
        private readonly ILoggerServer _logger;
        private readonly string _ip;
        private readonly int _port;
        public static readonly List<IRequest> RequestsCommands = new List<IRequest>();
        public Server(ILoggerServer logger, string ip, int port)
        {
            this._logger = logger;
            this._ip = ip;
            this._port = port;
        }

        public void Start()
        {
            Console.WriteLine("Old Tanks Server 2019 by Fooxboy");
            _logger.Info("Запуск сервера...");
            var listener = new SocketConnectListener(_ip, _port, _logger);
            listener.NewConnectEvent += NewConnect;
        }

        private void NewConnect(string request, Socket socket)
        {
            if (request.Split(";")[0] == "login")
            {
                var response = new Login(socket).Execute(request.Split(";").ToList());
            }

            
        }
    }
}
