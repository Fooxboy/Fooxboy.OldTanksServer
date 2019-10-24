﻿using Fooxboy.OldTanksServer.Core;
using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public List<User> OnlineUsers { get; }
        public List<Lobby> Lobbys { get; }
        public Api Api { get; }
        public Server(ILoggerServer logger, string ip, int port)
        {
            this._logger = logger;
            this._ip = ip;
            this._port = port;
            Api = new Api();
            OnlineUsers = new List<User>();
            Lobbys = new List<Lobby>();
        }

        public void Start()
        {
            Console.WriteLine("Old Tanks Server 2019 by Fooxboy");
            _logger.Info("Запуск сервера...");
            HullHelper.GetHelper().InitHulls();
            TurretHelper.GetHelper().InitTurrets();
            ColormapHelper.GetHelper().InitColormaps();
            var listener = new SocketConnectListener(_ip, _port, _logger);
            listener.NewConnectEvent += NewConnect;
        }

        private void NewConnect(string request, Socket socket)
        {
            Task.Run(() =>
            {
                var userIp = ((IPEndPoint)socket.RemoteEndPoint).Address;
                var isBanned = Api.BannedIP.CheckBan(userIp.ToString());

                _logger.Info($"Игрок с IP:{userIp} подключился к серверу.");
                if (request.Split(";")[0] == "login")
                {
                    var result = new Login(socket, this).Execute(request.Split(";").ToList());
                    if (result.Status)
                    {
                        var user = Api.Account.GetUserFromId(result.Id);
                        var garage = Api.Garage.GetGarageFromId(result.Id);
                        this.OnlineUsers.Add(user);
                        var lobby = new Lobby(user, garage, socket, _logger);
                        Lobbys.Add(lobby);
                        lobby.LoadLobby();
                        lobby.UserDisconnected += ClientDisonnect;
                    }else
                    {
                        var message = $"error;{result.Error};";
                        var data = Encoding.Unicode.GetBytes(message);
                        socket.Send(data);
                    }
                }
            });
        }

        private void ClientDisonnect(Lobby lobby)
        {
            try
            {
                _logger.Info($"Пользователь {lobby.User.Nickname} отключился от сервера.");
                OnlineUsers.Remove(lobby.User);
                Lobbys.Remove(lobby);
                lobby.Socket.Shutdown(SocketShutdown.Both);
                lobby.Socket.Close();
                lobby.Socket.Dispose();
            }catch(Exception e)
            {
                lobby.Socket.Dispose();
                _logger.Error($"Ошибка при отключении клиента от сервера: \n {e}");
            }
        }
    }
}
