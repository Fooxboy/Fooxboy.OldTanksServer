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
        }
        private readonly List<string> _ranks;

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
    }
}
