using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SenderConsole
{
    public class Sender
    {
        public static void SendImage(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }


            List<IPAddress> receivers = DiscoverRecivers();

            foreach (var ip in receivers)
            {
                Console.WriteLine($"Sending to {ip}");

                try
                {
                    TcpClient client = new TcpClient(ip.ToString(), 5000);
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] fileBytes = File.ReadAllBytes(filePath);
                        stream.Write(fileBytes, 0, fileBytes.Length);
                    }
                    client.Close();
                }
                catch
                {
                    Console.WriteLine($"Failed to send to {ip}");
                }
            }
        }

        private static List<IPAddress> DiscoverRecivers()
        {
            List<IPAddress> list = new List<IPAddress>();

            using (UdpClient udp = new UdpClient())
            {
                udp.EnableBroadcast = true;

                byte[] msg = Encoding.UTF8.GetBytes("DISCOVER");

                udp.Send(msg, msg.Length, new IPEndPoint(IPAddress.Broadcast, 9000));

                udp.Client.ReceiveTimeout = 2000;

                Console.WriteLine("Discovering receivers...");

                DateTime start = DateTime.Now;

                while ((DateTime.Now - start).TotalSeconds < 2)
                {
                    try
                    {
                        IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                        byte[] data = udp.Receive(ref ep);

                        string response = Encoding.UTF8.GetString(data);

                        if (response == "READY")
                        {
                            if (!list.Contains(ep.Address))
                            {
                                list.Add(ep.Address);
                                Console.WriteLine($"Found: {ep.Address}");
                            }
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            return list;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to send image...");
            Console.ReadLine();

            SendImage(@"C:\Users\SEZ-A4\Downloads\Spotify v9.1.36.1948 (Premium).zip");

            Console.ReadLine();
        }
    }
}
