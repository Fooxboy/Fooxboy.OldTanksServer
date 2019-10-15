using Fooxboy.OldTanksServer.Helpers;
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
        private readonly User _user;
        private readonly Garage _garage;
        private readonly Socket _socket;
        private readonly RequestProccessor _proccessor;
        public Lobby(User currentUser, Garage garage, Socket socket):base(socket)
        {
            this._user = currentUser;
            this._socket = socket;
            this._garage = garage;
            this._proccessor = new RequestProccessor();
        }

        public void LoadLobby()
        {
            Task.Run(()=> ListerNewRequest());
            var message = $"lobby;{_user.Nickname};{_garage.Crystalls};{_garage.Score};номер текущего корпуса;номер текущей башни;номер краски";
            this.Send(message);
            if (_user.IsSpector) this.Send("spector;");
        }

        public void ListerNewRequest()
        {
            while(true)
            {
                if (_socket.Available == 0) return;
                var builder = new StringBuilder();
                int bytes = 0;
                byte[] data = new byte[256];
                do
                {
                    bytes = _socket.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (_socket.Available > 0);
                var message = builder.ToString();
                var response = _proccessor.Start(message);
                this.Send(response);
            }
            
        }
    }
}
