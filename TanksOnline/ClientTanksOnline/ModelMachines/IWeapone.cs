using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ModelMachines
{
	interface IWeapone
	{
		int GetDamage();
		int GetDamageArmor();
	}
}
