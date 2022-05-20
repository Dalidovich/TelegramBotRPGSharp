using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using TelegramBotRPG;

namespace YPTelegramBotRPG
{
    public static class Places
    {
        public static async void welcome(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = NotifyEvent.ToString() + Player.ToString();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot,replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
        }
        public static async void endGame(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = NotifyEvent.ToString() + Player.ToString() + NotifyEvent.statistic();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnEndGame());
        }
    }
}
