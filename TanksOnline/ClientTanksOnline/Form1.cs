﻿using ClientTanksOnline.ModelTank;
using ClientTanksOnline.ModelTank.Cannon;
using ClientTanksOnline.ModelTank.Health;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTanksOnline
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			IMachines tank = new Tank();
			
		}
	}
}
