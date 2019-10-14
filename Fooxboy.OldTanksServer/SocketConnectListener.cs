using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer
{
    public class SocketConnectListener
    {
        private Socket _serverSocket;
        private IPEndPoint _ipPoint;
        private ILoggerServer _logger;
        public event NewConnectDelegate NewConnectEvent;
        public SocketConnectListener(string ip, int port, ILoggerServer logger)
        {
            var address = ip == "localhost" ? Dns.GetHostEntry(ip).AddressList[0] : IPAddress.Parse(ip);
            _ipPoint = new IPEndPoint(address, port);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _logger = logger;
        }

        public void Run()
        {
            try
            {
                _serverSocket.Bind(_ipPoint);
                _serverSocket.Listen(10);
                StartListenRequests();
            }
            catch(Exception e)
            {
                _logger.Error($"Произошла ошибка при старте SocketServerListener: {e}");
            }
        }

        private void StartListenRequests()
        {
            while (true)
            {
                try
                {
                    var handler = _serverSocket.Accept();
                    var builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    try
                    {
                        var message = NewConnectEvent?.Invoke(builder.ToString(), handler);
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                    }catch(Exception e)
                    {
                        _logger.Error($"Произошла ошибка при отправке ответа: {e}");
                    }
                }catch(Exception e)
                {
                    _logger.Error($"Произошла ошибка при получении запроса: {e}") ;
                }
                
            }
        }
    }
}
