using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline
{
	interface IMachines
	{
		int GetDamage();
		int GetDamageProtection();
		int GetArmor();
		int GetArmorProtection();
		int GetSpeed();
		void UpWeapone();
		void UpArmor();
	}
}
