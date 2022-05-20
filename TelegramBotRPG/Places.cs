using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;

namespace YPTelegramBotRPG
{
    public static class Places
    {
        public static async void welcome(Player player,Message m, ITelegramBotClient botClient)
        {
            //ReplyKeyboardMarkup markup = new(new[]
            //{
            //    new ReplyKeyboardMarkup[]{"next room","quit"},
            //    new ReplyKeyboardMarkup[]{"use hp potion"}
            //})
            string messageFromBot = NotifyEvent.display() + player;
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot);
        }
    }
}
