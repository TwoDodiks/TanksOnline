using ClientTanksOnline.ModelMachines.Armor;
using ClientTanksOnline.ModelMachines.Cannon;
using ClientTanksOnline.ModelMachines.Health;
using System.Windows.Forms;

namespace ClientTanksOnline.ModelMachines
{
	class LightTank :IMachines
	{
		 IHealth health;
		 IWeapone weapone;
		 IArmor armor;
		public LightTank()
		{
			this.weapone = new CannonLV1();
			this.armor = new ArmorLV1();
			this.health = new HealthLV1();
		}

		public PictureBox Picture => throw new System.NotImplementedException();

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

		public void UpArmor()
		{
			this.armor = new ArmorLV2();
		}

		public void UpWeapone()
		{
			this.weapone = new CannonLV2();
		}
	}
}
