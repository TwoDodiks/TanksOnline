using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank.Health
{
	class HealthLV1 : IHealth
	{
		int health;
		public int GetHealth()
		{
			return health;
		}
		public void SetHealth(int health)
		{
			this.health = health;
		}
		public HealthLV1(int health=10)
		{
			this.health = health;
		}
	}
}
