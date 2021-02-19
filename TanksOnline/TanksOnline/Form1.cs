using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline
{
	public partial class Form1 : Form
	{

		static TcpClient tcpClient;
		static TcpListener tcpListener;
		static NetworkStream networkStream;
		public Form1()
		{
			InitializeComponent();
			tcpListener = new TcpListener(IPAddress.Any, 8000);
			tcpListener.Start();
			Console.WriteLine("Start");
			tcpClient = tcpListener.AcceptTcpClient();
			Traffic traffic = new Traffic();
			Thread thread = new Thread(new ThreadStart(traffic.GetAction));
			thread.Start();
			networkStream = tcpClient.GetStream();
		}
		class Traffic
		{

			public void GetAction()
			{
				Position position = new Position();
				while (true)
				{
					byte[] bytes = new byte[1024];
					int size = 0;
					StringBuilder stringBuilder = new StringBuilder();
					do
					{
						networkStream.Read(bytes, 0, bytes.Length);
						position = ByteArrayToObject(bytes);


					} while (networkStream.DataAvailable);

				}

			}
			private byte[] ObjectToByteArray(Position obj)
			{
				if (obj == null)
					return null;

				BinaryFormatter bf = new BinaryFormatter();
				MemoryStream ms = new MemoryStream();
				bf.Serialize(ms, obj);

				return ms.ToArray();
			}

			// Convert a byte array to an Object
			private Position ByteArrayToObject(byte[] arrBytes)
			{
				MemoryStream memStream = new MemoryStream();
				BinaryFormatter binForm = new BinaryFormatter();
				memStream.Write(arrBytes, 0, arrBytes.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				Position obj = (Position)binForm.Deserialize(memStream);

				return obj;
			}
		}
		[Serializable]
		class Position
		{
			public int X { get; set; } = 50;
			public int Y { get; set; } = 50;
			public int Speed { get; set; }
			public bool Up { get; set; } = true;
			public bool Down { get; set; } = false;
			public bool Left { get; set; } = false;
			public bool Righ { get; set; } = false;
		}
	}
}
