using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Player : Character
	{
		public int Level { get; set; }
		public string Name { get; }
		public string chad { get; }
		public int AttackPower { get; set; }
		public int DefensivePower { get; set; }
		public int Health { get; set; }
		public int Gold { get; set; }

		public Player(string Name, string chad)
		{

			Level = 01;
			this.Name = Name;
			this.chad = chad;
			AttackPower = 10;
			DefensivePower = 5;
			Health = 100;
			Gold = 1500;
		}

		public void PlayerDead()
		{
			Console.Clear();
			Console.WriteLine($"{Name} 이 죽었습니다..");
		}
	}
}
