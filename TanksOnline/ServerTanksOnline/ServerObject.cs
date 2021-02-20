using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline
{
	class ServerObject
	{
		static TcpListener tcpListener;
		List<ClientObject> clients = new List<ClientObject>();
		protected internal void AddConnection(ClientObject clientObject)
		{
			clients.Add(clientObject);
		}
		protected internal void RemoveConnection(string Id)
		{
			ClientObject client = clients.FirstOrDefault(x => x.Id == Id);
			if (client != null) clients.Remove(client);
		}
		//Отправить действие
		protected internal void ActionBroadCast(byte[]data,string id)
		{
			for (int i = 0; i < clients.Count; i++)
			{
				if (clients[i].Id != id)
					clients[i].Stream.Write(data, 0, data.Length);
			}
		}
		protected internal void Listen()
		{
			try
			{
				string IP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork).ToString();

				tcpListener = new TcpListener(IPAddress.Any, 8000);
				tcpListener.Start();
				while(true)
				{
					TcpClient tcpClient = tcpListener.AcceptTcpClient();
					ClientObject clientObject = new ClientObject(tcpClient, this);
					clientObject.Process();
					//Thread thread = new Thread(new ThreadStart(clientObject.Process));
					//thread.Start();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + " Listen");
				Disconnect();
			}
		}
		protected internal void Disconnect()
		{
		
		}
	}
}
