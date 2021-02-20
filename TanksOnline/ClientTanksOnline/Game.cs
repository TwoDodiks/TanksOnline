using ClientTanksOnline.ModelMachines;
using Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTanksOnline
{
	public partial class Game : Form
	{
		Serialization.ObjectAction position = new ObjectAction();
		public TcpClient tcpClient;
		NetworkStream networkStream;
		IMachines tank1 = new Tank();
		public Game()
		{
			InitializeComponent();
			tcpClient = new TcpClient();
			tcpClient.Connect("127.0.0.1", 8000);
			networkStream = tcpClient.GetStream();
			tank1.Picture.Location = new Point(position.X, position.Y);

			position.X = 50;
			position.Y = 50;
			position.Speed = tank1.GetSpeed();
			this.Controls.Add(tank1.Picture);
			Thread thread = new Thread(new ThreadStart(GetAction));
			thread.Start();
			this.KeyDown += Form2_KeyDown;
		}

		private void Form2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Down) position.Up = true; else position.Up = false;
			if (e.KeyData == Keys.Up) position.Down = true; else position.Down = false;
			if (e.KeyData == Keys.Left) position.Left = true; else position.Left = false;
			if (e.KeyData == Keys.Right) position.Righ = true; else position.Righ = false;
			SendAction();
		}
		private void SendAction()
		{
			byte[] data = Serialization.Serialization.ObjectToByteArray(position);
			networkStream.Write(data, 0, data.Length);
		}
		private void GetAction()
		{
			while (true)
			{
				byte[] data = new byte[1024];
				do
				{
					networkStream.Read(data, 0, data.Length);



					position = (Serialization.ObjectAction)Serialization.Serialization.ByteArrayToObject(data);
				} while (networkStream.DataAvailable);
				tank1.Picture.Location = new Point(position.X, position.Y);
			}
		}
	}
}
