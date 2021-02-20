using ClientTanksOnline.ModelMachines.Armor;
using ClientTanksOnline.ModelMachines.Cannon;
using ClientTanksOnline.ModelMachines.Health;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTanksOnline.ModelMachines
{
	class Tank : IMachines
	{
		IHealth health;
		IWeapone weapone;
		IArmor armor;
	    PictureBox picture;
		
		public Tank()
		{
			this.picture = new PictureBox();
			this.picture.Image = Image.FromFile("lt.png");
			this.picture.Size = new Size(40, 40);
			this.picture.SizeMode = PictureBoxSizeMode.StretchImage;
			this.weapone = new CannonLV1();
			this.armor = new ArmorLV1();
			this.health = new HealthLV1(15);
		}

		public PictureBox Picture => picture;

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
			return 3;
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
