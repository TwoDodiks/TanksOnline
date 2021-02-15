using ClientTanksOnline.ModelTank;
using ClientTanksOnline.ModelTank.Cannon;
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
			tank.Weapone(new CannonLV1());
			this.Text = tank.GetCannon.ToString();
			CannonLV2 cannon = new CannonLV2();
			cannon = (CannonLV2)tank.GetCannon;
			IMachines light = new LightTank();
			
		}
	}
}
