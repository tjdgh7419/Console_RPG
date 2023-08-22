/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Enhanc
	{
		bool En_Suc; //강화 성공
		bool En_Fail;
		public void EnhanceOn()
		{
			bool[] storeItem_chk = new bool[5];
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("강화하기");
			Console.ResetColor();
			Console.WriteLine("무기를 강화하는 곳입니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			Console.WriteLine("강화할 무기를 선택하세요.");
			Console.WriteLine();
			for (int i = 0; i < items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Name,-6}  | 공격력 +{items[i].AttackPower} | {items[i].Information,-10}");
				}
				else if (items[i].AttackPower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Name,-6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information,-10}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": Enhance(items[0]); break;
					case "2": Enhance(items[1]); break;
					case "3": Store(); break;
					case "4": Dungeon(); break;
					case "5": RestOn(); break;
					case "0": GameStart(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void Enhance(Item E_Item)
		{
			int EnhanceCost = 200 * (E_Item.EnhanceNum + 1) + (20 * E_Item.EnhanceNum);
			Random EnhanceChance = new Random();
			int enNum = EnhanceChance.Next(1, 101);
			int E_Chance = (E_Item.EnhanceNum * 10) + (E_Item.EnhanceNum * 5);
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("강화하기");
			Console.ResetColor();
			Console.WriteLine("무기를 강화하는 곳입니다.");
			Console.WriteLine();
			Console.WriteLine("[현재 선택된 아이템]");
			if (E_Item.AttackPower > 0)
			{
				Console.WriteLine($"이름 : {E_Item.Name}");
				Console.WriteLine($"공격력: {E_Item.AttackPower}");
			}
			else
			{
				Console.WriteLine($"이름 : {E_Item.Name}");
				Console.WriteLine($"방어력 : {E_Item.DefensivePower}");
			}
			Console.WriteLine();
			Console.WriteLine($"강화수치 : + {E_Item.EnhanceNum}     |     보유 골드 : {player.Gold} G");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"1회 강회 비용: {EnhanceCost} G     |     강화 확률 : {100 - E_Chance} %");
			Console.WriteLine();
			if (En_Suc) Console.WriteLine("강화를 성공하였습니다!");
			if (En_Fail) Console.WriteLine("강화를 실패하였습니다..");
			Console.WriteLine();
			Console.WriteLine("1. 강화하기");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			En_Suc = false;
			En_Fail = false;
			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1":
						if (player.Gold > EnhanceCost)
						{
							player.Gold -= EnhanceCost;
							if (E_Chance < enNum)
							{
								if (E_Item.AttackPower > 0)
								{
									E_Item.EnhanceNum += 1;
									E_Item.AttackPower += 1 * E_Item.EnhanceNum + 1;
									En_Suc = true;
									Enhance(E_Item);
								}
								else
								{
									E_Item.EnhanceNum += 1;
									E_Item.DefensivePower += 1 * E_Item.EnhanceNum + 1;
									En_Suc = true;
									Enhance(E_Item);
								}
							}
							else
							{
								if (E_Item.EnhanceNum >= 3)
								{
									E_Item.EnhanceNum -= 1;
								}
								En_Fail = true;
								Enhance(E_Item);
							}
						}
						else
						{
							Console.WriteLine("소지금이 부족합니다!");
						}
						break;
					case "0": EnhanceOn(); break;

					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
	}
}
			*/
		
