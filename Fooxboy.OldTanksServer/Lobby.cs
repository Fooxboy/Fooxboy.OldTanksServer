using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.OldTanksServer
{
    public class Lobby: SocketHelper
    {
        public readonly User User;
        public readonly Garage Garage;
        public readonly Socket Socket;
        private readonly RequestProccessor _proccessor;
        private readonly ILoggerServer _logger;
        public Lobby(User currentUser, Garage garage, Socket socket, ILoggerServer log):base(socket)
        {
            this.User = currentUser;
            this.Socket = socket;
            this.Garage = garage;
            this._proccessor = new RequestProccessor(socket, this);
        }

        public void LoadLobby()
        {
            Task.Run(()=> ListerNewRequest());
            var message = $"lobby;{User.Nickname};{Garage.Crystalls};{Garage.Score};номер текущего корпуса;номер текущей башни;номер краски";
            this.Send(message);
            if (User.IsSpector) this.Send("spector;");
        }

        public void ListerNewRequest()
        {
            while(true)
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
    }
}
