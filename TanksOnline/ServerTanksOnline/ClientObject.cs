using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TanksOnline
{
	class ClientObject
	{
		public string Id { get; set; }
		public NetworkStream Stream { get; set; }
		public ObjectAction objectAction { get; set; }
		TcpClient client;
		private ServerObject serverObject;

		private delegate void SomeAction();
		public ClientObject(TcpClient client,ServerObject serverObject)
		{
			objectAction = new ObjectAction();
			this.client = client;
			this.serverObject = serverObject;
			this.Id = Guid.NewGuid().ToString();
			serverObject.AddConnection(this);

		}
		internal void Process()
		{
			try
			{
				Stream = client.GetStream();
				Object temp;


				while (true)
				{
					byte[] data = new byte[1024];
					do
					{
						Stream.Read(data, 0, data.Length);
						temp = Serialization.Serialization.ByteArrayToObject(data);

					} while (Stream.DataAvailable);
					objectAction = (ObjectAction)temp;
					NewAction();
					SendAction();
					serverObject.ActionBroadCast(Serialization.Serialization.ObjectToByteArray(serverObject),this.Id);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message+ " Process");
			}
		}
		internal void SendAction()
		{
			byte[] data = Serialization.Serialization.ObjectToByteArray(objectAction);
			Stream.Write(data, 0, data.Length);
		}
		internal ObjectAction NewAction()
		{
			if (objectAction.Up)
			{
				objectAction.Y += objectAction.Speed;

			}
			if (objectAction.Down)
			{
				objectAction.Y -= objectAction.Speed;
			}
			if (objectAction.Left)
			{
				objectAction.X -= objectAction.Speed;
			}
			if (objectAction.Righ)
			{
				objectAction.X += objectAction.Speed;
			}

			return objectAction;
		}
	}
}
