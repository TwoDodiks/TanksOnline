using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelMachines.Cannon
{
	class CannonLV2:IWeapone
	{
		const int damage = 2;
		const int armor_damage = 1;
		public int GetDamage()
		{
			return damage;
		}

		public int GetDamageArmor()
		{
			return armor_damage;
		}
	}
}
