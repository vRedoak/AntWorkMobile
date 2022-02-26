using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        private const string host = "192.168.43.11";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;
        public Page1 ()
		{
			InitializeComponent ();
            client = new TcpClient();
        }

        private async void Send_Clicked(object sender, EventArgs e)
        {
            await client.ConnectAsync(host, port);
            if (client.Connected)
            {
                Connection.Instance.client = client;

                stream = client.GetStream();
                String s = "Viktoriya";
                byte[] message = Encoding.Unicode.GetBytes(s);
                stream.Write(message, 0, message.Length);
            }
        }
    }
    public class Connection
    {
        private static Connection _instance;

        public static Connection Instance
        {
            get
            {
                if (_instance == null) _instance = new Connection();
                return _instance;
            }
        }
        public TcpClient client { get; set; }
    }
}