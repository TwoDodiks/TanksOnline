using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank.Cannon
{
	public class CannonLV1:IWeapone
	{ 
		const int damage = 1;
		const int armor_damage = 0;
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
