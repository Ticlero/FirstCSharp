using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.IO;
namespace TelegramBot
{
    public partial class TelegramBot : Form
    {
        private static readonly Telegram.Bot.TelegramBotClient Bot = new TelegramBotClient("910742741:AAGNwe-O-F2U2pw9bN41AbTQhGDIGv4L41k");
        public TelegramBot()
        {
            InitializeComponent();
        }

        private async void TelegramAPI()
        {
            //var Bot = new Telegram.Bot.TelegramBotClient("910742741:AAGNwe-O-F2U2pw9bN41AbTQhGDIGv4L41k");
            //var me = await Bot.GetMeAsync();
            this.Text = "My_TelegramBot";
            var me = Bot.GetMeAsync().Result;
            Console.WriteLine("Hello My name is {0}", me.FirstName);

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.StartReceiving();
            //Bot.StopReceiving();
        }

        private void TelegramBot_Load(object sender, EventArgs e)
        {
            TelegramAPI();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text)
                return;

            if(e.Message.Type == MessageType.Text)
            {
                if(e.Message.Text == "/예린")
                {
                    //var response = Bot.SendTextMessageAsync(chatId: "@YRSHlovenews", "hello");
                    //Console.WriteLine(response);
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "예린아 사랑해~~ 오빠가");
                }else if(e.Message.Text == "/며칠?" || e.Message.Text == "/ㅁㅊ" || e.Message.Text == "/며칠" )
                {
                    string datingDate = new DateTime(2017, 04, 04).ToShortDateString();
                    string nowDate = DateTime.Now.ToShortDateString();
                    TimeSpan span = DateTime.Parse(nowDate) - DateTime.Parse(datingDate);
                    string dDay = span.ToString();
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, $"우리가 벌써 사귄지! " + dDay.Substring(0,3) + "일 이나 됐오!!♥♥♥♥♥♥♥" 
                        + e.Message.Chat.Username);
                }
                else if (e.Message.Text == "/사랑해")
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, @"울 사당둥이 이뿌니 린둥이 링뽀!
오빠도 많이많이 사당해여!!
♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥
♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");

                }
                else if(e.Message.Text == "/인라인")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                   {
                        new [] // first row
                        {
                            InlineKeyboardButton.WithCallbackData("1.1"),
                            InlineKeyboardButton.WithCallbackData("1.2"),
                            

                        },
                        new [] // second row
                        {
                            InlineKeyboardButton.WithCallbackData("2.1"),
                            InlineKeyboardButton.WithCallbackData("2.2")
                        }
                    });
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Choose", replyMarkup: inlineKeyboard);
                }else if(e.Message.Text == "/키보드")
                {
                    ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "1.1", "1.2" },
                        new[] { "2.1", "2.2" },
                    };

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Choose",
                        replyMarkup: ReplyKeyboard);
                }
                else
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, @"사용법 : 
/예린 - 오빠가 사랑하는 마음을 듬뿍 담아 사랑해 라는 말을 해준다.

/며칠 - 2017년 풋풋했던 대학생때 만나 현재 까지의 사귄 날짜를 말 해준다!
(/ㅁㅊ ,/며칠 가능)
/사랑해 오빠가 사랑하는 마음을 더욱 더 듬뿍 담아 사랑해 라는 말을 해준다.
/인라인 - 개발중
/키보드 - 개발중");

                }
            }

            //await Bot.SendTextMessageAsync(message.Chat.Id, message.Text);

            
        }

        private async void MyBot()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("testItem01"),
                    new KeyboardButton("testItem02")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("testItem03")
                }
            };
            
        }
    }
}
