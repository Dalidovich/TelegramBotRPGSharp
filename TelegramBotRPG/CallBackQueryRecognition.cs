using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using YPTelegramBotRPG;

namespace TelegramBotRPG
{
    public static class CallBackQueryRecognition
    {
        public static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            if (callbackQuery.Data == "q")
            {
                Places.endGame(callbackQuery.Message, botClient);
            }
            //await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "lol", replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
            return;
        }
    }
}
