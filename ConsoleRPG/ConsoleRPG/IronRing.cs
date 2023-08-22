﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class IronRing : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public bool equipped { get; set; }
		public string Sign { get; set; }

		public IronRing(string Name, int DefensivePower, string Information)
		{
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
			AttackPower = 0;
			Price = 400;
			I_Exist = false;
			equipped = false;
			Sign = "";
		}
	}
}
