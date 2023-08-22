using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public interface Character
	{
		int Level { get; set; }
		string Name { get; }
		string chad { get; }
		int AttackPower { get; set; }
		int DefensivePower { get; set; }
		int Health { get; set; }
		int Gold { get; set; }
		void PlayerDead();
	}
}
