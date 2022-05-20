using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public static class NotifyEvent
    {
        public static List<string> lines = new List<string>();
        public static int countRooms = 0;
        public static int countKills = 0;
        public static int countDrunkPotion = 0;
        public static int countTakeDamage = 0;
        public static int countGiveDamage = 0;
        public static int countRegenPoints = 0;
        public static void addMessage(string m)
        {
            lines.Add(m);
        }
        public static new string ToString()
        {
            string txt = "";
            foreach (var item in lines)
            {
                txt += item + "\n";
            }
            return txt+"\n";
        }
        public static void clearLines() => lines.Clear();
        public static void clearStatistic()
        {
            countRooms = 0;
            countKills = 0;
            countDrunkPotion = 0;
            countTakeDamage = 0;
            countGiveDamage = 0;
            countRegenPoints = 0;
        }
        public static string statistic()
        {
            return $"\n" +
                   $"count reserch Rooms: {countRooms}\n" +
                   $"count kills: {countKills}\n" +
                   $"count use HP potion: {countDrunkPotion}\n" +
                   $"count damage which player take: {countTakeDamage}\n" +
                   $"count damage which player give: {countGiveDamage}\n" +
                   $"count regen hp potions: {countRegenPoints}\n";
        }
    }
}
