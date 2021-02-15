using ClientTanksOnline.ModelTank.Armor;
using ClientTanksOnline.ModelTank.Cannon;
using ClientTanksOnline.ModelTank.Health;

namespace ClientTanksOnline.ModelTank
{
	class LightTank :IMachines
	{
		readonly IHealth health;
		readonly IWeapone weapone;
		readonly IArmor armor;
		public LightTank()
		{
			this.weapone = new CannonLV1();
			this.armor = new ArmorLV1();
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
