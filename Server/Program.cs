using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        public static List<string> _list;
        private static void ProcessClientRequests(object argument) {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                string s = string.Empty;
                while (s != null)
                {
                    s = reader.ReadLine();
                    Console.WriteLine("read string from client:" + s);
                   // writer.WriteLine("From server: " + s);
                   // writer.Flush();

                    bool b = false;
                    foreach (string ss in _list)
                    {
                        if (s == ss)
                        {
                            b = true;
                            Console.WriteLine("Writing 'true'");
                            writer.WriteLine("true");
                            writer.Flush();
                        }
                    }
                    if (b == false)
                    {
                        Console.WriteLine("Writing 'false'");
                        Console.WriteLine("Country: " + s + " is not in " +
                            "list of valid countries");
                        writer.WriteLine("false");
                        writer.Flush();
                    }
                    


                }
                reader.Close();
                writer.Close();
                client.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication.");
            }
            finally
            {
                if (client != null) client.Close();
            }

        }

        static void Main(string[] args)
        {
            _list = new List<string>();

            _list.Add("Ukraine");
            _list.Add("USA");
            _list.Add("Poland");
            _list.Add("Russia");
            _list.Add("Colombia");
            _list.Add("Slovakia");


            TcpListener listener = null;

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"),8080);
                listener.Start();
                
                while (true) {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                       /* bool b = false;
                        foreach (string ss in _list) {
                            if (s == ss){
                                b = true;
                                Console.WriteLine("Writing 'true'");
                                writer.WriteLine("true");
                                writer.Flush();
                            }
                            if (b == false) {
                                Console.WriteLine("Writing 'false'");
                                writer.WriteLine("false");
                                writer.Flush();
                            }
                        }*/
                    }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                if(listener != null)
                    listener.Stop();
            }
        }
    }
}
