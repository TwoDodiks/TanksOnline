﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanksOnline
{
	interface IMachines
	{
		PictureBox Picture { get; }
		int GetDamage();
		int GetDamageProtection();
		int GetArmor();
		int GetArmorProtection();
		int GetSpeed();
		void UpWeapone();
		void UpArmor();

	}
}
