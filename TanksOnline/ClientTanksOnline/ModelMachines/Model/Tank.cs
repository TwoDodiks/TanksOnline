using ClientTanksOnline.ModelMachines.Armor;
using ClientTanksOnline.ModelTank.Cannon;
using ClientTanksOnline.ModelTank.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank
{
	class Tank : IMachines
	{
		readonly IHealth health;
		readonly IWeapone weapone;
		readonly IArmor armor;
		public Tank()
		{
			this.weapone = new CannonLV2();
			this.armor = new ArmorLV2();
			this.health = new HealthLV1();
		}
		public int GetArmor()
		{
			return armor.GetArmor();
		}

		public int GetArmorProtection()
		{
			return armor.GetArmorProtection();
		}

		public int GetDamage()
		{
			return weapone.GetDamage();
		}

		public int GetDamageProtection()
		{
			return weapone.GetDamageArmor();
		}

		public int GetSpeed()
		{
			return 5;
		}
	}
}
