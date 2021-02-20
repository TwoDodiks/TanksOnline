using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ModelMachines.Armor
{
	class ArmorLV1:IArmor
	{
		const int armor = 0;
		const int armor_protection = 0;
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
