using System.Reflection.Emit;
using System;

namespace ConsoleRPG
{
	public interface Character
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

	public interface Item
	{
		string Name { get; set; }
		int DefensivePower { get; set; }
		string Information { get; set; }
	}

	public class IronArmor : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }

		public IronArmor(string Name, int DefensivePower, string Information) 
		{ 
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
		}
	}
	public class Start
	{
		private Character player;
		private List<Item> items;
		public Start(Player player, List<Item>items)
		{
			this.player = player;
			this.items = items;
		}

		public void GameStart()
		{
			Console.Clear();
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
				case "2": InventoryOn(); break;
			}
	
		}
		
		public void InventoryOn()
		{
			
			Console.WriteLine("인벤토리");
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			Console.WriteLine($"- {items[0].Name}      | 방어력 +{items[0].DefensivePower} | {items[0].Information}");
			Console.WriteLine("1. 장착 관리");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");
			string input = Console.ReadLine();

			switch(input)
			{
				case "0": GameStart(); break;
			}
		}

		public void StateOn()
		{
			Console.Clear();
			Console.WriteLine("상태 보기");
			Console.WriteLine("캐릭터의 정보가 표시됩니다");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"이름 : {player.Name}");
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
			string input = Console.ReadLine();
			switch(input)
			{
				case "0" : GameStart(); break;
			}
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Item>items = new List<Item> { new IronArmor("무쇠갑옷", 5, "튼튼한 갑옷") };
			Player player = new State("Sungho" , "전사");
			Start start = new Start(player, items);

			start.GameStart();			
		}
	}
}