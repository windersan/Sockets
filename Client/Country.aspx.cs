
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Net.Sockets;

public partial class Country : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = TextBox1.Text;


        try
        {
            TcpClient client = new TcpClient("127.0.0.1", 8080);
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());


            writer.WriteLine(s);
            writer.Flush();
            string ss = reader.ReadLine();

            client.Close();
        }
        catch (SocketException ex)
        {
            Console.WriteLine("SocketException: {0}", ex);
        }


    }
}