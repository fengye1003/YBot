using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace XhgdSharpMC
{
    internal class LogReader
    {
        public MCRcon r;
        public XhMirai m;
        public string LastLog;
        public string LastMsg;

        public LogReader(MCRcon r, XhMirai m)
        {
            this.r = r;
            this.m = m;
            try
            {

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                File.Copy("./logs/latest.log", "./logs/2ndLog.log", true);
                LastLog = File.ReadAllText("./logs/2ndLog.log", Encoding.GetEncoding("GB2312"));
            }
            catch(Exception ex)
            {
                Log.SaveLog(ex.ToString());
                Thread.Sleep(100);
                ReTry();
            }
        }
        void ReTry()
        {
            try
            {

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                File.Copy("./logs/latest.log", "./logs/2ndLog.log", true);
                LastLog = File.ReadAllText("./logs/2ndLog.log", Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.ToString());
                Thread.Sleep(100);
                ReTry();
            }
        }
        public async Task ReadLog()
        {
            string Group;
            Group = File.ReadAllText("./YbotConfig/QQ/group.txt");
            string NowLog;
            try
            {

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                File.Copy("./logs/latest.log", "./logs/2ndLog.log", true);
                NowLog = File.ReadAllText("./logs/2ndLog.log", Encoding.GetEncoding("GB2312"));
                Log.SaveLog("成功重新加载日志");
            }
            catch(Exception ex)
            {
                Log.SaveLog(ex.ToString());
                Thread.Sleep(100);
                return;
            }
            string NowLog2 = NowLog.Replace(LastLog, "");
            if (NowLog2 == "") 
            {
                Log.SaveLog("无新增日志");
                return;
            }
            //await m.SendToGroup($"[服务器内信息-发送者:{playerName}] {logText}", "1037084535");
            //string NowLog2 = "[20:47:04] [Async Chat Thread - #54/INFO]: <fengye1003xbox> 1\n[20:47:39] [Async Chat Thread - #54/INFO]: <fengye1003xbox> 2333\n[20:47:42][Async Chat Thread - #54/INFO]: <fengye1003xbox> 你好\n[20:47:48][Async Chat Thread - #54/INFO]: <fengye1003xbox> 草泥马";
            string[] LogTemp = NowLog2.Split("\n");
            foreach (string LogLine in LogTemp)
            {
                string[] LogTmp = LogLine.Split("<");
                LogTmp[0] = "";
                string logText = "";
                foreach (string log in LogTmp)
                {
                    logText += log;
                }
                LogTmp = logText.Split(">");
                string playerName = LogTmp[0];
                LogTmp[0] = "";
                logText = "";
                foreach (string log in LogTmp)
                {
                    logText += log;
                }
                if (logText == "")
                {

                }
                else
                {
                    if (LogLine.Contains("<") || LogLine.Contains(">") || !LogLine.Contains("[Rcon]") || logText != LastMsg)  
                    {
                        await m.SendToGroup($"[服务器内信息-发送者:{playerName}] {logText}", Group);
                        LastMsg = logText;
                    }
                }
                //1037084535
                //1149944741
            }
            LastLog = NowLog;
            return;
        }
    }
}
