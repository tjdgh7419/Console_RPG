using System.Reflection.Emit;
using System;

namespace ConsoleRPG
{
	interface Character
	{
		int Level { get; }
		string Name { get; set; }
		string chad { get; set; }
		int AttackPower { get; }
		int DefensivePower { get; }
		int Health { get; }
		int Gold { get; }
	}

	public class Player : Character
	{
		public int Level { get;}
		public string Name { get; set; }
		public string chad { get; set; }
		public int AttackPower { get; }
		public int DefensivePower { get; }
		public int Health { get; }
		public int Gold { get; }

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


	}
	public class State : Player
	{
		public State(string Name, string chad) : base(Name, chad) { }

	}
	public class Start
	{
		private Character player;
	
		public Start(Player player)
		{
			this.player = player;
		}

		public void GameStart()
		{
			Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
			Console.WriteLine("이곳에서 던전을 들어가기 전 활동을 할 수 있습니다.");
			Console.WriteLine();

			Console.WriteLine("1. 상태 보기");
			Console.WriteLine("2. 인벤토리");
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			string input = Console.ReadLine();

			switch(input)
			{
				case "1": StateOn(); break;
			}
	
		}

		public void StateOn()
		{
			
			Console.WriteLine("상태 보기");
			Console.WriteLine("캐릭터의 정보가 표시됩니다");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Lv {player.Level}");
			Console.WriteLine($"Chad ( {player.chad} )");
			Console.WriteLine($"공격력 : {player.AttackPower}");
			Console.WriteLine($"방어력 : {player.DefensivePower}");
			Console.WriteLine($"체 력 : {player.Health}");
			Console.WriteLine($"Gold : {player.Gold}");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Player player = new State("Sungho" , "전사");
			Start start = new Start(player);

			start.GameStart();
			
		}
	}
}