using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RconSharp;

namespace XhgdSharpMC
{
    class MCPosition
    {
        public int x;
        public int y;
        public int z;
        public MCPosition(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    internal class MCRcon
    {
        public MCRcon(RconClient rc)
        {
            this.rc = rc;
        }
        public RconClient rc;
        #region Command and Logs
        public async Task Execute(string Command)
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync(Command);
        }
        public async Task SaveLog(string Text, string Source)
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync($"say [{Source}] {Text}");
        }
        public async Task Stop(int WaitTime)
        {
            await rc.ConnectAsync();
            MCRcon r = new MCRcon(rc);
            await r.SetActionBar("即将关闭服务器..");
            Thread.Sleep(3000);
            for (int i = WaitTime; i > 1; i--)
            {
                await r.SetActionBar($"距离服务器关闭还有{i}秒...");
                Thread.Sleep(1000);
            }
            await r.Execute("stop");
        }
        #endregion
        #region Chat and title
        public async Task Say(string Text)
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync("say " + Text);
        }
        public async Task SetMainTitle(string Text, string Player = "@a")
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync("title " + Player + " title \"" + Text + "\"");
        }
        public async Task SetSubTitle(string Text, string Player = "@a")
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync("title " + Player + " subtitle \"" + Text + "\"");
        }
        public async Task SetActionBar(string Text, string Player = "@a")
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync("title " + Player + " actionbar \"" + Text + "\"");
        }
        #endregion
        #region Blocks
        public async Task Fill(int xFrom, int yFrom, int zFrom, int xTarget, int yTarget, int zTarget, string Block = "air")
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync($"fill {xFrom} {yFrom} {zFrom} {xTarget} {yTarget} {zTarget} {Block}");
        }
        public async Task SetBlock(int x, int y, int z, string Block = "air")
        {
            await rc.ConnectAsync();
            await rc.ExecuteCommandAsync($"setblock {x} {y} {z} {Block}");
        }
        #endregion

        public async Task ReConnect()
        {
            await rc.ConnectAsync();
        }

    }
}
