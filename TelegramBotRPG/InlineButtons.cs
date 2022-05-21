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
        public static IReplyMarkup GetButtonsOnFight()
        {
            return new InlineKeyboardMarkup
            (
                new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("1") { Text = "atack",CallbackData="a"}, new InlineKeyboardButton("2") { Text = "dodge",CallbackData = "d" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("3") { Text = "use hp potion",CallbackData = "uhpf" } //call back data means fight
                    }
                }
            );
        }
        public static IReplyMarkup GetButtonsOnDodge()
        {
            return new InlineKeyboardMarkup
            (
                new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("1") { Text = "atack",CallbackData="a"}, new InlineKeyboardButton("2") { Text = "escape",CallbackData = "de" }
                    },
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("3") { Text = "use hp potion",CallbackData = "uhpd" } //call back data means dodge
                    }
                }
            );
        }
        public static IReplyMarkup GetButtonsOnEndGame()
        {
            return new InlineKeyboardMarkup
            (
                new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("1") { Text = "restart",CallbackData="rest"}
                    },
                }
            );
        }
        public static IReplyMarkup GetButtonsOnLifeAltar()
        {
            return new InlineKeyboardMarkup
            (
                new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton>
                    {
                        new InlineKeyboardButton("1") { Text = "potion power",CallbackData="pu"}, new InlineKeyboardButton("2") { Text = "max hp",CallbackData = "hu" }
                    }
                }
            );
        }
    }
}
