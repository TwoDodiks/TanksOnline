﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline
{
	interface IHealth
	{
		int GetHealth();
		void SetHealth(int health);
	}
}
