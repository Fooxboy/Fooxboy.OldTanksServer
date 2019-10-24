using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Helpers
{
    public class RankHelper
    {
        private static RankHelper _helper;
        private RankHelper() 
        {
            _ranks = new List<string>() { "Новобранец", "Рядовой", "Ефрейтор", "Капрал", 
                "Мастер-капрал", "Сержант", "Штаб-сержант", "Мастер-сержант", "Первый сержант",
            "Сержант-Майор", "Уорэнт-офицер 1", "Уорэнт-офицер 2", "Уорэнт-офицер 3", "Уорэнт-офицер 4", 
                "Уорэнт-офицер 5", "Младший лейтенант", "Лейтенант", "Старший лейтенант", "Капитан",
            "Майор", "Подполковник", "Полковник", "Бригадир", "Генерал-майор", "Генерал-лейтенант", 
                "Генерал", "Маршал"};

            _rankScores = new List<long>() { 100, 500, 1500, 3700,
                7100, 12300, 20000, 29000, 41000, 57000, 76000, 98000,
                125000, 156000, 192000, 233000, 280000, 332000, 390000,
                455000, 527000, 606000, 692000, 787000, 889000, 1000000 };


        }
        private readonly List<string> _ranks;
        private readonly List<long> _rankScores;

        public static RankHelper GetHelper()
        {
            _helper ??= new RankHelper();
            return _helper;
        }

        public string ConvertNumberToString(int rank)
        {
            if (rank < 0 || rank > 26) return "Неизвесный ранг";
            return _ranks[rank];
        }

        public long GetRankFromScore(long score)
        {
            var rankNumber = 0;
            foreach (var rankScore in _rankScores) if (rankScore > score) rankNumber++; else break;
            return rankNumber;
        }

        public string ConvertScoreToString(long score)
        {
            var number = GetRankFromScore(score);
            return ConvertNumberToString(Convert.ToInt32(number));
        }
    }
}
