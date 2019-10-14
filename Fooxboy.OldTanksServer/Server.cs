using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class Server
    {
        private readonly ILoggerServer _logger;
        private readonly string _ip;
        private readonly int _port;
        private readonly RequestProccessor _proccessor;
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
            var listener = new SocketServerListener(_ip, _port, _logger);
            listener.NewRequestEvent += Listener_NewRequestEvent;
            
        }

        private string Listener_NewRequestEvent(string request)=> _proccessor.Start(request);
    }
}
