using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.Server
{
	class ClientObject
	{
		public NetworkStream Stream { get; set; }
		TcpClient client;
		private ServerObject server;
		public string Id { get; set; }
		public ClientObject(TcpClient tcpClient,ServerObject serverObject)
		{
			this.client = tcpClient;
			this.server = serverObject;
			this.Id = Guid.NewGuid().ToString();
			server.AddConnection(this);
		}
		protected internal void Process()
		{
			try
			{
				Stream = client.GetStream();
				while (true)
				{


				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		internal void Close()
		{
			if (Stream != null)
				Stream.Close();
			if (client != null)
				client.Close();
		}
	}
}
