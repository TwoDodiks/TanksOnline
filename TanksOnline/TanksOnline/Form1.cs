using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			PictureBox picture = new PictureBox();
			this.Controls.Add(picture);
		}
	}
}
