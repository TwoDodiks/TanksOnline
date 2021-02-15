using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank.Cannon
{
	public class CannonLV1:ICannon
	{ 
		public const int damage = 1;
		public const int armor_damage = 0;
		public int Damage { get=>damage; }
	}
}
