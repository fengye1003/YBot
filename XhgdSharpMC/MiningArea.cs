using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RconSharp;

namespace XhgdSharpMC
{
    internal class MiningArea
    {
        public MiningArea(RconClient r, MCPosition pF, MCPosition pT)
        {
            this.r = r;
            this.pF = pF;
            this.pT = pT;
        }
        public RconClient r;
        public MCPosition pF, pT;
        public async void InitializeMiningArea()
        {
            int redstoneLeast, redstoneMost, ironLeast, ironMost, diamondLeast, diamondMost, coalLeast, coalMost, lapisLeast, lapisMost, goldLeast, goldMost, boneLeast, boneMost, lavaLeast, lavaMost, waterLeast, waterMost;
            Directory.CreateDirectory("./YbotConfig/MiningArea/");
            if (File.Exists("./YbotConfig/MiningArea/redstoneLeast.txt"))
            {
                redstoneLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/redstoneLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/redstoneLeast.txt", "50");
                redstoneLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/redstoneLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/redstoneMost.txt"))
            {
                redstoneMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/redstoneMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/redstoneMost.txt", "200");
                redstoneMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/redstoneMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/ironLeast.txt"))
            {
                ironLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/ironLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/ironLeast.txt", "100");
                ironLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/ironLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/ironMost.txt"))
            {
                ironMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/ironMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/ironMost.txt", "500");
                ironMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/ironMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/diamondMost.txt"))
            {
                diamondMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/diamondMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/diamondMost.txt", "100");
                diamondMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/diamondMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/diamondLeast.txt"))
            {
                diamondLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/diamondLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/diamondLeast.txt", "50");
                diamondLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/diamondLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/coalLeast.txt"))
            {
                coalLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/coalLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/coalLeast.txt", "500");
                coalLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/coalLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/coalMost.txt"))
            {
                coalMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/coalMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/coalMost.txt", "600");
                coalMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/coalMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/lapisMost.txt"))
            {
                lapisMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lapisMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/lapisMost.txt", "300");
                lapisMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lapisMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/lapisLeast.txt"))
            {
                lapisLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lapisLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/lapisLeast.txt", "200");
                lapisLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lapisLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/goldLeast.txt"))
            {
                goldLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/goldLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/goldLeast.txt", "200");
                goldLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/goldLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/goldMost.txt"))
            {
                goldMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/goldMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/goldMost.txt", "300");
                goldMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/goldMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/boneMost.txt"))
            {
                boneMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/boneMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/boneMost.txt", "400");
                boneMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/boneMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/boneLeast.txt"))
            {
                boneLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/boneLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/boneLeast.txt", "300");
                boneLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/boneLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/lavaLeast.txt"))
            {
                lavaLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lavaLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/lavaLeast.txt", "300");
                lavaLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lavaLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/lavaMost.txt"))
            {
                lavaMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lavaMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/lavaMost.txt", "400");
                lavaMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/lavaMost.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/waterLeast.txt"))
            {
                waterLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/waterLeast.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/waterLeast.txt", "300");
                waterLeast = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/waterLeast.txt"));
            }
            if (File.Exists("./YbotConfig/MiningArea/waterMost.txt"))
            {
                waterMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/waterMost.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/waterMost.txt", "400");
                waterMost = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/waterMost.txt"));
            }
            int[] temp;
            MCRcon r = new MCRcon(this.r);
            int xF, yF, zF, xT, yT, zT, redstone, diamond, iron, coal, lapis, gold, bone, lava, water;
            string Block;
            xF = pF.x;
            yF = pF.y;
            zF = pF.z;
            xT = pT.x;
            yT = pT.y;
            zT = pT.z;
            Block = "stone";
            Random random = new Random();
            redstone = random.Next(redstoneLeast, redstoneMost);
            Log.SaveLog("Finished.");
            iron = random.Next(ironLeast, ironMost);
            Log.SaveLog("Finished.");
            diamond = random.Next(diamondLeast, diamondMost);
            Log.SaveLog("Finished.");
            coal = random.Next(coalLeast, coalMost);
            Log.SaveLog("Finished.");
            lapis = random.Next(lapisLeast, lapisMost);
            Log.SaveLog("Finished.");
            gold = random.Next(goldLeast, goldMost);
            Log.SaveLog("Finished.");
            bone = random.Next(boneLeast, boneMost);
            Log.SaveLog("Finished.");
            lava = random.Next(lavaLeast, lavaMost);
            Log.SaveLog("Finished.");
            water = random.Next(waterLeast, waterMost);
            int WaitTime;
            if (File.Exists("./YbotConfig/MiningArea/WaitTime.txt"))
            {
                WaitTime = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/WaitTime.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/WaitTime.txt", "90");
                WaitTime = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/WaitTime.txt"));
            }
            int NextTime;
            if (File.Exists("./YbotConfig/MiningArea/NextTime.txt"))
            {
                NextTime = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/NextTime.txt"));
            }
            else
            {
                File.WriteAllText("./YbotConfig/MiningArea/NextTime.txt", "7200");
                NextTime = Convert.ToInt32(File.ReadAllText("./YbotConfig/MiningArea/NextTime.txt"));
            }
            string kq = "矿区进程-初始化";
            await r.SaveLog($"矿区坐标读取:{xF} {yF} {zF} to {xT} {yT} {zT}.", kq);
            await r.SaveLog($"填充物:{Block}", kq);
            await r.SetActionBar("即将填充整个矿区,请所有人员撤离矿区");
            Thread.Sleep(3000);
            for (int i = WaitTime; i > -1; i--) 
            {
                await r.SetActionBar($"距离矿区填充还有{i}秒,请所有人员撤离矿区.");
                Thread.Sleep(1000);
            }
            await r.SetActionBar($"开始填充矿区...");
            await r.Fill(xF, yF, zF, xT, yT, zT, Block);
            
            for (int i = 0; i < redstone; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "redstone_ore");
            }
            for (int i = 0; i < iron; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "iron_ore");
            }
            for (int i = 0; i < coal; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "coal_ore");
            }
            for (int i = 0; i < lapis; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "lapis_ore");
            }
            for (int i = 0; i < bone; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "bone_block");
            }
            for (int i = 0; i < diamond; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "diamond_ore");
            }
            for (int i = 0; i < gold; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "gold_ore");
            }
            for (int i = 0; i < lava; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "lava");

            }
            for (int i = 0; i < water; i++)
            {
                temp = RandomTarget(xF, yF, zF, xT, yT, zT);
                await r.SetBlock(temp[0], temp[1], temp[2], "water");

            }

            await r.SaveLog($"<矿区进程>填充完成!", kq);
            Thread.Sleep(2000);
            await r.SaveLog($"<矿区进程>距离下次填充还有{NextTime}秒", kq);
            Thread.Sleep(NextTime * 1000);
            InitializeMiningArea();
        }
        public int[] RandomTarget(int xF, int yF, int zF, int xT, int yT, int zT)
        {
            Random random = new Random();
            int rx;
            int ry;
            int rz;
            if (xT < xF)
            {
                rx = random.Next(xT, xF);
            }
            else
            {
                rx = random.Next(xF, xT);
            }

            if (yT < yF)
            {

                ry = random.Next(yT, yF);
            }
            else
            {
                ry = random.Next(yF, yT);
            }

            if (zT < zF)
            {

                rz = random.Next(zT, zF);
            }
            else
            {
                rz = random.Next(zF, zT);
            }
            int[] Target = new int[3];
            Target[0] = rx;
            Target[1] = ry;
            Target[2] = rz;
            return Target;
        }
    }
}
