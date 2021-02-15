using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline.Server
{
	class ServerObject 
	{
		static TcpListener tcpListener;
		List<ClientObject> clients = new List<ClientObject>();
		string ipEnd = "127.0.0.1";

		protected internal void AddConnection(ClientObject client)
		{
			clients.Add(client);
		}
		protected internal void RemoveConnection(string id)
		{
			ClientObject client = clients.FirstOrDefault(x => x.Id == id);
			if (client != null)
				clients.Remove(client);
		}
		protected internal void Listen()
		{
			try
			{
				tcpListener = new TcpListener(IPAddress.Parse(ipEnd), 8000);
				tcpListener.Start();

				while (true)
				{
					TcpClient temp = tcpListener.AcceptTcpClient();

					ClientObject clientObject = new ClientObject(temp, this);
					Thread thread = new Thread(new ThreadStart(clientObject.Process));
					thread.Start();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Disconnect();
			}
		}
		protected internal void SendData()
		{
			
			
		}
		public static byte[] ObjectToByteArray(Object obj)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (var ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}
		protected internal void Disconnect()
		{
			tcpListener.Stop();
			for (int i = 0; i < clients.Count; i++)
			{
				clients[i].Close();
			}
		}
	}
}
