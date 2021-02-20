using TanksOnline.ModelMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ModelMachines.Armor
{
	class ArmorLV2 :IArmor
	{
		const int armor = 1;
		const int armor_protection = 1;
		public int GetArmor()
		{
			return armor;
		}

		public int GetArmorProtection()
		{
			return armor_protection;
		}
	}
}
