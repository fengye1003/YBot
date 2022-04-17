using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;


namespace XhgdSharpMC
{
    internal class XhMirai
    {
        public string LastMessage = "";
        public XhMirai(MiraiBot m)
        {
            this.bot = m;
        }
        public MiraiBot bot;
        public MCRcon r;
        bool running = false;
        public void Listen()
        {
            string Group;
            Group = File.ReadAllText("./YbotConfig/QQ/group.txt");
            try
            {
                Console.WriteLine("Powered by Mirai. Based on EachTech .NET Project.");

                //await bot.LaunchAsync();

                bot.MessageReceived
                    .OfType<GroupMessageReceiver>()
                    .Subscribe(async x =>
                    {
                        if (running)
                        {
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            running = true;
                        }
                        Log.SaveLog($"收到了来自群{x.GroupId}由{x.Sender.Id}发送的消息：{x.MessageChain.GetPlainMessage()}");
                        if (LastMessage == x.MessageChain.GetPlainMessage())
                        {
                            Log.SaveLog("重复信息");
                        }
                        else
                        {
                            if (x.MessageChain.GetPlainMessage() == "")
                            {
                                await MessageDriver($"不支持的消息类型或空白信息.发送者:{x.Sender.Name}");
                            }
                            else
                            {
                                if (x.MessageChain.GetPlainMessage().Contains("<") || x.MessageChain.GetPlainMessage().Contains(">")) 
                                {
                                    await SendToGroup("此信息含有尖括号,为了防止逻辑错误,禁止发送", Group);
                                }
                                else
                                {
                                    await MessageDriver(x);
                                    LastMessage = x.MessageChain.GetPlainMessage();
                                }
                            }
                            
                        }
                        running = false;
                    //1149944741

                    });

                bot.MessageReceived
                    .OfType<FriendMessageReceiver>()
                    .Subscribe(x =>
                    {
                        Log.SaveLog($"收到了来自好友{x.Sender.Id}发送的消息：{x.MessageChain.GetPlainMessage()}");
                    });

                bot.MessageReceived
                    .OfType<StrangerMessageReceiver>()
                    .Subscribe(x =>
                    {
                        Log.SaveLog($"收到了来自陌生人{x.Sender.Id}发送的消息：{x.MessageChain.GetPlainMessage()}");
                    });

                bot.MessageReceived
                    .OfType<OtherClientMessageReceiver>()
                    .Subscribe(x =>
                    {

                    });
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Log.SaveLog(ex.ToString());
                Listen();
            }
            
        }
        public async Task MessageDriver(GroupMessageReceiver x)
        {
            string Group;
            Group = File.ReadAllText("./YbotConfig/QQ/group.txt");
            try
            {
                if (x.GroupId == Group)
                {
                    await r.SaveLog($"{x.MessageChain.GetPlainMessage()}", $"YBot-发送者:{x.Sender.Name}");
                }
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.ToString());
                await r.ReConnect();
                await MessageDriver(x);
            }

        }
        public async Task MessageDriver(string x)
        {
            try
            {
                await r.SaveLog($"{x}", $"YBot-提示");
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.ToString());
                await r.ReConnect();
                await MessageDriver(x);
            }

        }
        public async Task SendToGroup(string Text,string GroupId)
        {

            try
            {
                await bot.LaunchAsync();
                await MessageManager.SendGroupMessageAsync(GroupId, Text.Replace("<", "").Replace(">", ""));
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.ToString());

            }
        }
    }
}
