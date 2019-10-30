using Fooxboy.OldTanksServer.Core;
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
        public readonly ILoggerServer Logger;
        private readonly string _ip;
        private readonly int _port;
        public static readonly List<IRequest> RequestsCommands = new List<IRequest>();
        public List<User> OnlineUsers { get; }
        public List<Lobby> Lobbies { get; }
        public Api Api { get; }
        public Server(ILoggerServer logger, string ip, int port)
        {
            this.Logger = logger;
            this._ip = ip;
            this._port = port;
            Api = new Api(this);
            OnlineUsers = new List<User>();
            Lobbies = new List<Lobby>();
        }

        public void Start()
        {
            Console.WriteLine("Old Tanks Server 2019 by Fooxboy");
            Logger.Info("Запуск сервера...");
            HullHelper.GetHelper().InitHulls();
            TurretHelper.GetHelper().InitTurrets();
            ColormapHelper.GetHelper().InitColormaps();
            NumericHelper.GetHelper().InitNumerics();
            var listener = new SocketConnectListener(_ip, _port, Logger);
            listener.NewConnectEvent += NewConnect;
        }

        private void NewConnect(string request, Socket socket)
        {
            Task.Run(() =>
            {
                var userIp = ((IPEndPoint)socket.RemoteEndPoint).Address;
                var isBanned = Api.BannedIP.CheckBan(userIp.ToString());
                if(isBanned)
                {
                    Logger.Info($"[CONNECT]=> Игрок с IP:{userIp} не смог подключился к серверу, потому что его IP заблокирован.");
                    var message = $"error;Ваш IP адрес заблокирован.;";
                    var data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);

                    try
                    {
                        Logger.Info($"Пользователь c IP:{userIp} отключен от сервера.");
                       
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        socket.Dispose();
                    }
                    catch (Exception e)
                    {
                        socket.Dispose();
                        Logger.Error($"Ошибка при отключении клиента от сервера: \n {e}");
                    }
                    return;
                }

                Logger.Info($"[CONNECT]=> Игрок с IP:{userIp} подключился к серверу.");
                if (request.Split(";")[0] == "login")
                {
                    var result = new Login(socket, this).Execute(request.Split(";").ToList());
                    if (result.Status)
                    {
                        var user = Api.Account.GetUserFromId(result.Id);
                        var garage = Api.Garage.GetGarageFromId(result.Id);
                        this.OnlineUsers.Add(user);
                        var lobby = new Lobby(user, garage, socket, Logger);
                        Lobbies.Add(lobby);
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
                Logger.Info($"Пользователь {lobby.User.Nickname} отключился от сервера.");
                OnlineUsers.Remove(lobby.User);
                Lobbies.Remove(lobby);
                lobby.Socket.Shutdown(SocketShutdown.Both);
                lobby.Socket.Close();
                lobby.Socket.Dispose();
            }catch(Exception e)
            {
                lobby.Socket.Dispose();
                Logger.Error($"Ошибка при отключении клиента от сервера: \n {e}");
            }
        }
    }
}
