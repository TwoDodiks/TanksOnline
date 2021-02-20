using ClientTanksOnline.ModelMachines;

using System;

using Serialization;
using System.Net.Sockets;

using System.Windows.Forms;

namespace ClientTanksOnline
{
	public partial class Form1 : Form
	{

		Serialization.Position position = new Position();
		public TcpClient tcpClient;
		NetworkStream networkStream;
		IMachines tank1 = new Tank();
		public Form1()
		{
			InitializeComponent();
			
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.ShowDialog();
			this.Close();
			//tcpClient = new TcpClient();
			//tcpClient.Connect("127.0.0.1", 8000);
			//networkStream = tcpClient.GetStream();

			//tank1.Picture.Location = new Point(position.X, position.Y);

			//position.X = 50;
			//position.Y = 50;
			//position.Speed = tank1.GetSpeed();


			//this.Controls.Add(tank1.Picture);

			//Thread thread = new Thread(new ThreadStart(GetTraffic));
			//thread.Start();
		}
	}
}
