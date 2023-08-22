using System.Reflection.Emit;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace ConsoleRPG
{
	
	public class Start
	{
		public static Start _instance = null;
		public static Start Instance()
		{
			if (_instance == null)
			{
				_instance = new Start();
			}

			return _instance;
		}
		
		public int AttackUP = 0;
		public int DefensiveUP = 0;
		public Player player = new State("Sungho", "전사");
		public List<Item> store_Items = new List<Item>
			{ new GoldSword("황금검", 8, "금으로 만들어진 검입니다."),
			  new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다."),
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다."),
			  new Sword("검", 4, "튼튼한 검입니다."),
			  new IronRing("철반지", 3, "은으로 만들어진 반지입니다.")
			};

		public List<Item> items = new List<Item> { };
		public Start()
		{
			items.Add(store_Items[1]);
			items.Add(store_Items[2]);
		}
		
		public void GameStart()
		{
			Enhanc eh = new Enhanc();
			Rest rs = new Rest();
			DungeonStage ds = new DungeonStage();
			StoreStage st = new StoreStage();
			Inventory it = new Inventory();
			Console.Clear();
			Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
			Console.WriteLine("이곳에서 던전을 들어가기 전 활동을 할 수 있습니다.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("1. 상태 보기");
			Console.WriteLine();
			Console.WriteLine("2. 인벤토리");
			Console.WriteLine();
			Console.WriteLine("3. 상점");
			Console.WriteLine();
			Console.WriteLine("4. 던전입장");
			Console.WriteLine();
			Console.WriteLine("5. 휴식하기");
			Console.WriteLine();
			Console.WriteLine("6. 강화하기");
			Console.WriteLine();
			Console.ResetColor();
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": StateOn(); break;
					case "2": it.InventoryOn(); break;
					case "3": st.Store(); break;
					case "4": ds.Dungeon(); break;
					case "5": rs.RestOn(); break;
					case "6" : eh.EnhanceOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}			


		public void StateOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("상태 보기");
			Console.ResetColor();
			Console.WriteLine("캐릭터의 정보가 표시됩니다");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"이름 : {player.Name}");
			Console.WriteLine($"Lv {player.Level}");
			Console.WriteLine($"Chad ( {player.chad} )");
			if (AttackUP > 0)
			{
				Console.WriteLine($"공격력 : {player.AttackPower} (+{AttackUP})");
			}
			else
			{
				Console.WriteLine($"공격력 : {player.AttackPower}");
			}
			if (DefensiveUP > 0)
			{
				Console.WriteLine($"방어력 : {player.DefensivePower} (+{DefensiveUP})");
			}
			else
			{
				Console.WriteLine($"방어력 : {player.DefensivePower}");
			}
			Console.WriteLine($"체 력 : {player.Health}");
			Console.WriteLine($"Gold : {player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.WriteLine(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Item> store_Items = new List<Item>
			{ new GoldSword("황금검", 8, "금으로 만들어진 검입니다."),
			  new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다."),
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다."),
			  new Sword("검", 4, "튼튼한 검입니다."),
			  new IronRing("철반지", 3, "은으로 만들어진 반지입니다.")
			};

			List<Item> items = new List<Item>()
			{ };

			items.Add(store_Items[1]);
			items.Add(store_Items[2]);

			Player player = new State("Sungho", "전사");

			Start start = new Start();
			start.GameStart();
		}
	}
}