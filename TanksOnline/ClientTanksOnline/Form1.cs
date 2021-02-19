using ClientTanksOnline.ModelMachines;
using ClientTanksOnline.ModelMachines.Cannon;
using ClientTanksOnline.ModelMachines.Health;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
		[Serializable()]
		class Positions
		{
			public	 int X { get; set; } = 50;
			public	 int Y { get; set; } = 50;
			public  int Speed { get; set; }
			public  bool Up { get; set; } = true;
			public  bool Down { get; set; } = false;
			public  bool Left { get; set; } = false;
			public  bool Righ	{ get; set; } = false;
		}
		Positions Position = new Positions();
		public TcpClient tcpClient;
		NetworkStream networkStream;
		public Form1()
		{
			InitializeComponent();
			tcpClient = new TcpClient();
			tcpClient.Connect("127.0.0.1", 8000);
			networkStream = tcpClient.GetStream();

			Thread thread = new Thread(new ThreadStart(GetTraffic));
			thread.Start();

			IMachines tank1 = new Tank();
			tank1.Picture.Location = new Point(Position.X, Position.Y);
			
			Position.Speed = tank1.GetSpeed();
			this.Controls.Add(tank1.Picture);
			
		}
		
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Down) Position.Up = true; else Position.Up = false;
			if (e.KeyData == Keys.Up) Position.Down = true; else Position.Down = false;
			if (e.KeyData == Keys.Left) Position.Left = true; else Position.Left = false;
			if (e.KeyData == Keys.Right) Position.Righ = true; else Position.Righ = false;
			SendTraffic();

		}
		private void SendTraffic()
		{
			byte[] data  = ObjectToByteArray(Position);
			networkStream.Write(data, 0, data.Length);
		}
		private void GetTraffic()
		{




		}
		private byte[] ObjectToByteArray(Positions obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);

			return ms.ToArray();
		}

		// Convert a byte array to an Object
		private Object ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			Object obj = (Object)binForm.Deserialize(memStream);

			return obj;
		}
	}
}
