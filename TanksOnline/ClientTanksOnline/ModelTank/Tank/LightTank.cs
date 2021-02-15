using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTanksOnline.ModelTank
{
	class LightTank : IMachines
	{
		public ICannon GetCannon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public IArmor GetArmor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public IMachines Armor(IArmor armor)
		{
			throw new NotImplementedException();
		}

		public IMachines Weapone(ICannon cannon)
		{
			throw new NotImplementedException();
		}
	}
}
