﻿using ClientTanksOnline.ModelMachines;
using ClientTanksOnline.ModelMachines.Cannon;
using ClientTanksOnline.ModelMachines.Health;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Serialization;
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

		Serialization.Position position = new Position();
		public TcpClient tcpClient;
		NetworkStream networkStream;
		IMachines tank1 = new Tank();
		public Form1()
		{
			InitializeComponent();
			this.KeyPress += Form1_KeyPress;
			this.KeyDown += Form1_KeyDown1;
		}

		private void Form1_KeyDown1(object sender, KeyEventArgs e)
		{
			MessageBox.Show("Key Down");
		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			MessageBox.Show("Key Press");
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Down) position.Up = true; else position.Up = false;
			if (e.KeyData == Keys.Up) position.Down = true; else position.Down = false;
			if (e.KeyData == Keys.Left) position.Left = true; else position.Left = false;
			if (e.KeyData == Keys.Right) position.Righ = true; else position.Righ = false;
			SendTraffic();
		}
		private void SendTraffic()
		{
			byte[] data  = Serialization.Serialization.ObjectToByteArray(position);
			networkStream.Write(data, 0, data.Length);
		}
		private void GetTraffic()
		{
			while (true)
			{
				byte[] data = new byte[1024];
				do
				{
					networkStream.Read(data, 0, data.Length);
					position = (Serialization.Position)Serialization.Serialization.ByteArrayToObject(data);
				} while (networkStream.DataAvailable);
				tank1.Picture.Location = new Point(position.X, position.Y);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
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
