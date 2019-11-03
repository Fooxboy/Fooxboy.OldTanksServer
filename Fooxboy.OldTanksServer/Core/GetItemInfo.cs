using Fooxboy.OldTanksServer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class GetItemInfo : IRequest
    {
        public string Trigger => "gi";

        public string Execute(List<string> message, Lobby lobby)
        {
            var itemId = long.Parse(message[1]);
            var type = message[2];
            var garage = lobby.Garage;
            var userRank = RankHelper.GetHelper().GetRankFromScore(garage.Score);

            if(type == "hull")
            {
                var hull = HullHelper.GetHelper().Hulls.Single(h => h.Id == itemId);
                if(garage.Hulls.Any(h=> h.Id == hull.Id))
                {
                    var hullUser = garage.Hulls.Single(h => h.Id == hull.Id);
                    var isCurrent = garage.CurrentHull.Id == hull.Id ? 1 : 0;

                    if(hullUser.Level == 3) return $"gi;h;{itemId};8;{isCurrent};";

                    if (garage.Crystalls >= hull.Prices[0] && userRank >= hull.Ranks[0]) return $"gi;h;{itemId};4;{hull.Prices[Convert.ToInt32(hullUser.Level + 1)]};{isCurrent};";
                    if (garage.Crystalls < hull.Prices[0] && userRank >= hull.Ranks[0]) return $"gi;h;{itemId};5;{hull.Prices[Convert.ToInt32(hullUser.Level + 1)]};{isCurrent};";
                    if (garage.Crystalls >= hull.Prices[0] && userRank < hull.Ranks[0]) return $"gi;h;{itemId};6;{hull.Prices[Convert.ToInt32(hullUser.Level + 1)]};{isCurrent};{hull.Ranks[Convert.ToInt32(hullUser.Level + 1)]}";
                    if (garage.Crystalls < hull.Prices[0] && userRank < hull.Ranks[0]) return $"gi;h;{itemId};7;{hull.Prices[Convert.ToInt32(hullUser.Level + 1)]};{isCurrent};{hull.Ranks[Convert.ToInt32(hullUser.Level + 1)]}";
                }
                else
                {
                    if(garage.Crystalls >= hull.Prices[0] && userRank >= hull.Ranks[0]) return $"gi;h;{itemId};0;{hull.Prices[0]}";
                    if(garage.Crystalls < hull.Prices[0] && userRank >= hull.Ranks[0]) return $"gi;h;{itemId};1;{hull.Prices[0]}";
                    if(garage.Crystalls >= hull.Prices[0] && userRank < hull.Ranks[0]) return $"gi;h;{itemId};2;{hull.Prices[0]};{hull.Ranks[0]}";
                    if (garage.Crystalls < hull.Prices[0] && userRank < hull.Ranks[0]) return $"gi;h;{itemId};3;{hull.Prices[0]};{hull.Ranks[0]}";
                }
            }

            if(type == "turret")
            {
                var turret = TurretHelper.GetHelper().Turrets.Single(t => t.Id == itemId);
            }
            
        }
    }
}
