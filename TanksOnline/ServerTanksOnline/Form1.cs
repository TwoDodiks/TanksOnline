using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Serialization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTanksOnline
{
	public partial class Form1 : Form
	{

		static TcpClient tcpClient;
		static Socket host,client;
		static TcpListener tcpListener;
		static NetworkStream networkStream;
		public Form1()
		{
			InitializeComponent();

			//host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//host.Bind(new IPEndPoint(IPAddress.Any, 8000));
			//host.Listen(1);

			//client = host.Accept();
			//Listen();

			tcpListener = new TcpListener(IPAddress.Any, 8000);
			tcpListener.Start(2);
			Start();
		}
		private async void Start()
		{
			await Task.Run(() => 
			{ 
				while(true)
				{
					tcpClient = tcpListener.AcceptTcpClient();

					networkStream = tcpClient.GetStream();
					Thread thread = new Thread(new ThreadStart(GetAction));
					thread.Start();
				}

			});
			
		}
		public Position NewAction(ref Position position)
		{
			if(position.Up)
			{
				position.Y -= position.Speed;
				
			}
			if(position.Down)
			{
				position.Y += position.Speed;
			}
			if(position.Left)
			{
				position.X -= position.Speed;
			}
			if(position.Righ)
			{
				position.X += position.Speed;
			}

			return position;
		}
		public void GetAction()
		{
			try
			{
				Position position = new Position();
				while (true)
				{
					byte[] bytes = new byte[1024];
					do
					{
						networkStream.Read(bytes, 0, bytes.Length);
						Object temp = Serialization.Serialization.ByteArrayToObject(bytes);
						position = (Position)temp;

					} while (networkStream.DataAvailable);
					SendAction(NewAction(ref position));
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void SendAction(Position position)
		{

			byte[] data = Serialization.Serialization.ObjectToByteArray(position);
			networkStream.Write(data, 0, data.Length);
		}

		
	}
		
}

