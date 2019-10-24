using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Fooxboy.OldTanksServer
{
    public class Lobby: SocketHelper
    {
        public readonly User User;
        public readonly Garage Garage;
        public readonly Socket Socket;
        private readonly RequestProccessor _proccessor;
        public readonly ILoggerServer Logger;
        public event Action<Lobby> UserDisconnected;
        public bool UserIsConnected { get; set; }

        public Lobby(User currentUser, Garage garage, Socket socket, ILoggerServer logger):base(socket)
        {
            if (currentUser is null || garage is null || socket is null || logger is null) throw new ArgumentNullException("Ни одно из переданных параметров конструктору Lobby не может быть null");
            this.User = currentUser;
            this.Socket = socket;
            this.Garage = garage;
            this._proccessor = new RequestProccessor(socket, this);
            this.Logger = logger;
            UserIsConnected = true;
        }

        public void LoadLobby()
        {
            try
            {
                Task.Run(() => ListerNewRequest());
                Task.Run(() => CheckDisconnectUser());
                var message =
                    $"lobby;{User.Nickname};{Garage.Crystalls};{Garage.Score};{HullHelper.GetHelper().GetCurrentHull(Garage.CurrentHull)};{TurretHelper.GetHelper().GetCurrentTurret(Garage.CurrentTurret)};{Garage.CurrentColormap.Id}";
                this.Send(message);
                if (User.IsSpector) this.Send("spector;");
                Logger.Info($"[LOBBY]=> Пользователь {User.Nickname} зашел в игру.");
            }catch(Exception e)
            {
                Logger.Error($"[LOAD LOBBY]=> Ошибка при загрузке лобби:\n {e}");
                Logger.Trace("Отключаем ошибочное лобби...");
                UserDisconnected?.Invoke(this);
            }
            
        }

        public void ListerNewRequest()
        {
            while(UserIsConnected)
            {
                if (Socket.Available == 0) return;
                var builder = new StringBuilder();
                int bytes = 0;
                byte[] data = new byte[256];
                do
                {
                    bytes = Socket.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (Socket.Available > 0);
                var message = builder.ToString();
                var response = _proccessor.Start(message);
                this.Send(response);
            }
            
        }

        public void CheckDisconnectUser()
        {
            while(true)
            {
                Thread.Sleep(1000);
                try
                {
                    this.Send("ping;connect;");
                    if (!Socket.Connected) throw new Exception("Пользователь отключен.");
                }catch(Exception)
                {
                    UserDisconnected?.Invoke(this);
                    UserIsConnected = false;
                    break;
                }
            }
        }
    }
}
