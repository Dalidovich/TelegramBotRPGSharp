using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;

namespace TelegramBotRPG
{
    public static class InlineButtons
    {
        public static IReplyMarkup GetButtonsOnEmptyPlace()
        {
            return new InlineKeyboardMarkup
            (
                new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    { 
                        new InlineKeyboardButton("1") { Text = "next room",CallbackData="nr"}, new InlineKeyboardButton("2") { Text = "quit",CallbackData = "q" } 
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("3") { Text = "use hp potion",CallbackData = "uhpe" } //call back data means empty
                    }
                }
            );
        }
    }
}
