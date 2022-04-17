using System;
using RconSharp;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using Mirai.Net.Sessions;
using System.IO;

namespace XhgdSharpMC
{
    internal class Program
    {
        RconClient rcon;
        XhMirai xm;
        MCRcon r;
        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                Thread Main = new Thread(new ThreadStart(program.Start));
                Main.Start();
                while (true)
                {
                    Thread.Sleep(5000);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Main(args);
            }
        }
        async void Start()
        {
            string rconip;
            string rconPort;
            string rconPasswd;
            string MiraiAddress;
            string QQid;
            string Key;
            string Group;
            Log.SaveLog("主入口点:Main");
            Directory.CreateDirectory("./YbotConfig/");
            if (File.Exists("./YbotConfig/rcon-ip.txt"))
            {
                rconip = File.ReadAllText("./YbotConfig/rcon-ip.txt");
            }
            else
            {
                File.WriteAllText("./YbotConfig/rcon-ip.txt", "127.0.0.1");
                rconip = File.ReadAllText("./YbotConfig/rcon-ip.txt");
            }
            if (File.Exists("./YbotConfig/rcon-Port.txt"))
            {
                rconPort = File.ReadAllText("./YbotConfig/rcon-Port.txt");
            }
            else
            {
                File.WriteAllText("./YbotConfig/rcon-Port.txt", "25575");
                rconPort = File.ReadAllText("./YbotConfig/rcon-Port.txt");
            }
            if (File.Exists("./YbotConfig/rcon-Passwd.txt"))
            {
                rconPasswd = File.ReadAllText("./YbotConfig/rcon-Passwd.txt");
            }
            else
            {
                File.WriteAllText("./YbotConfig/rcon-Passwd.txt", "123456");
                rconPasswd = File.ReadAllText("./YbotConfig/rcon-Passwd.txt");
            }
            RconClient rcon = RconClient.Create(rconip, Convert.ToInt32(rconPort));
            await rcon.ConnectAsync();
            // Send a RCON packet with type AUTH and the RCON password for the target server
            var authenticated = await rcon.AuthenticateAsync(rconPasswd);
            if (authenticated)
            {
                string MiningFrom;
                string MiningTo;
                Directory.CreateDirectory("./YbotConfig/MiningArea/");
                if (File.Exists("./YbotConfig/MiningArea/from.txt"))
                {
                    MiningFrom = File.ReadAllText("./YbotConfig/MiningArea/from.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/MiningArea/from.txt", "-221,-18,207");
                    MiningFrom = File.ReadAllText("./YbotConfig/MiningArea/from.txt");
                }
                if (File.Exists("./YbotConfig/MiningArea/to.txt"))
                {
                    MiningTo = File.ReadAllText("./YbotConfig/MiningArea/from.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/MiningArea/from.txt", "-177,-2,239");
                    MiningTo = File.ReadAllText("./YbotConfig/MiningArea/from.txt");
                }
                //MCPosition pF = new MCPosition(-221, -18, 207);
                //MCPosition pT = new MCPosition(-177, -2, 239);
                MCPosition pF = new MCPosition(Convert.ToInt32(MiningFrom.Split(",")[0]), Convert.ToInt32(MiningFrom.Split(",")[1]), Convert.ToInt32(MiningFrom.Split(",")[2]));
                MCPosition pT = new MCPosition(Convert.ToInt32(MiningTo.Split(",")[0]), Convert.ToInt32(MiningTo.Split(",")[1]), Convert.ToInt32(MiningTo.Split(",")[2]));
                MiningArea ma = new MiningArea(rcon, pF, pT);
                Thread MiningWorker=new Thread(new ThreadStart(ma.InitializeMiningArea));
                MiningWorker.Start();
                this.rcon = rcon;
                MCRcon r = new MCRcon(rcon);
                this.r = r;
                Directory.CreateDirectory("./YbotConfig/QQ/");
                if (File.Exists("./YbotConfig/QQ/miraiAddress.txt"))
                {
                    MiraiAddress = File.ReadAllText("./YbotConfig/QQ/miraiAddress.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/QQ/miraiAddress.txt", "localhost:8080");
                    MiraiAddress = File.ReadAllText("./YbotConfig/QQ/miraiAddress.txt");
                }
                if (File.Exists("./YbotConfig/QQ/qqid.txt"))
                {
                    QQid = File.ReadAllText("./YbotConfig/QQ/qqid.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/QQ/qqid.txt", "2333333333");
                    QQid = File.ReadAllText("./YbotConfig/QQ/qqid.txt");
                }
                if (File.Exists("./YbotConfig/QQ/key.txt"))
                {
                    Key = File.ReadAllText("./YbotConfig/QQ/key.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/QQ/key.txt", "123456");
                    Key = File.ReadAllText("./YbotConfig/QQ/key.txt");
                }
                if (File.Exists("./YbotConfig/QQ/group.txt"))
                {
                    Group = File.ReadAllText("./YbotConfig/QQ/group.txt");
                }
                else
                {
                    File.WriteAllText("./YbotConfig/QQ/group.txt", "1149944741");
                    Group = File.ReadAllText("./YbotConfig/QQ/group.txt");
                }
                var bot = new MiraiBot
                {
                    Address = MiraiAddress,
                    QQ = QQid,
                    VerifyKey = Key
                };

                XhMirai xm = new XhMirai(bot);
                this.xm = xm;
                this.xm.r = r;
                await bot.LaunchAsync();
                await xm.SendToGroup($"Ybot:连接成功!", Group);
                await r.SaveLog("Ybot机器人:连接成功!", "YBot");
                Thread QQListener = new Thread(new ThreadStart(StartQQListening));
                QQListener.Start();
                

                Thread ServerLogReader = new Thread(new ThreadStart(StartServerListening));
                ServerLogReader.Start();
                ////await xm.SendToGroup($"[服务器内信息-发送者:a] b", "1037084535");

            }
            else
            {
                Log.SaveLog(rconip);
                Log.SaveLog(rconPort);
                Log.SaveLog(rconPasswd);
                Log.SaveLog("Invaild connection.");
            }
        }
        //await bot.LaunchAsync();
        public void StartQQListening()
        {
            xm.Listen();
        }
        public async void StartServerListening()
        {
            LogReader logReader = new LogReader(r, xm);
            while (true)
            {
                await logReader.ReadLog();
                Thread.Sleep(2000);
            }
        }
    }
}
