using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Reciverr
{
    class Receiver
    {
        static void Main(string[] args)
        {
            Receiver.Start();

            Console.ReadLine();
        }

        public static void Start()
        {
            Task.Run(() => StartUdpListener());
            Task.Run(() => StartTcpServer());
        }

        static void StartUdpListener()
        {
            using (UdpClient udp = new UdpClient(9000))
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 9000);

                Console.WriteLine("UDP Listening...");

                while (true)
                {
                    try
                    {
                        byte[] data = udp.Receive(ref ep);
                        string msg = Encoding.UTF8.GetString(data);

                        if (msg == "DISCOVER")
                        {
                            Console.WriteLine($"Discovery from {ep.Address}");

                            using (UdpClient reply = new UdpClient())
                            {
                                byte[] response = Encoding.UTF8.GetBytes("READY");
                                reply.Send(response, response.Length, ep);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"UDP Error: {ex.Message}");
                    }
                }
            }
        }

        // TCP: receive file
        static void StartTcpServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();

            Console.WriteLine("TCP Server started...");

            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();

                    Task.Run(() =>
                    {
                        try
                        {
                            string fileName = $"received_{DateTime.Now.Ticks}.jpg";

                            using (NetworkStream stream = client.GetStream())
                            using (FileStream fs = new FileStream(fileName, FileMode.Create))
                            {
                                stream.CopyTo(fs);
                            }

                            Console.WriteLine($"Image received: {fileName}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"TCP Error: {ex.Message}");
                        }
                        finally
                        {
                            client.Close();
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Server Error: {ex.Message}");
                }
            }
        }
    }
}