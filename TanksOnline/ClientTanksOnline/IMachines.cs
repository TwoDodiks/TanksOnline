using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank
{
	interface IMachines
	{
		IMachines Weapone(ICannon cannon);
		IMachines Armor(IArmor armor);
		ICannon GetCannon { get; set; }
		IArmor GetArmor { get; set; }
	}
}
