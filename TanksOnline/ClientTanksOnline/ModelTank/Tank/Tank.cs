using ClientTanksOnline.ModelTank.Cannon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank
{
	class Tank : IMachines
	{
		//int damage;
		//int armor_damage;
		//int health;
		//int armor;

		public ICannon cannon;
		private IArmor armor;

		public ICannon GetCannon { get=>cannon; set { cannon = value; } }
		public IArmor GetArmor { get => armor; set { armor = value; } }

		public IMachines Armor(IArmor armor)
		{
			this.armor = armor;
			return this;
		}

		public IMachines Weapone(ICannon cannon)
		{
			this.cannon = cannon;
			
			return this;
		}
		public Tank()
		{

		}
		private void A()
		{
			
		}
		
	}
}
