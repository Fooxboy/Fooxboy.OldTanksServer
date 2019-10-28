using Fooxboy.OldTanksServer.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class BuyGarage : IRequest
    {
        private readonly Api _api;
        public BuyGarage(Api api)
        {
            _api = api;
        }
        public string Trigger => "buyg";

        public string Execute(List<string> message, Lobby lobby)
        {
            var type = message[1];
            var itemId = Int32.Parse(message[2]);
            var count = type=="n"? Int32.Parse(message[3]): 0;
            var userRank = RankHelper.GetHelper().GetRankFromScore(lobby.Garage.Score);
            if(type =="h")
            {
                if (itemId == 3) return "error;Неизвестная ошибка";
            }
            
        }
    }
}
