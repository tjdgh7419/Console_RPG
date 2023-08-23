using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
	public class Inventory
	{
		bool atk = false;
		bool def = false;
		public Item? AtkItem = null;
		public Item? DefItem = null;
		Start s5 = Start.Instance();
		public void InventoryOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < s5.items.Count; i++)
			{

				if (s5.items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {s5.items[i].Sign}{s5.items[i].Name,-6} + {s5.items[i].EnhanceNum}  | 공격력 +{s5.items[i].AttackPower} | {s5.items[i].Information,-10}");
				}
				else
				{
					Console.WriteLine($"- {s5.items[i].Sign}{s5.items[i].Name,-6} + {s5.items[i].EnhanceNum} | 방어력 +{s5.items[i].DefensivePower} | {s5.items[i].Information,-10}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("1. 장착 관리");
			Console.WriteLine("2. 정렬(공격력)");
			Console.WriteLine("3. 정렬(방어력)");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.Write(">>");


			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1": InventoryManager(); break;
					case "0": s5.GameStart(); break;
					case "2": AttackPowerInventorySort(); InventoryOn(); break;
					case "3": DefensivePowerInventorySort(); InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void InventoryManager()
		{
			bool[] Display = new bool[5];
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리 - 장착 관리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < s5.items.Count; i++)
			{
				Display[i] = true;
				if (s5.items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {s5.items[i].Sign}{s5.items[i].Name,-6}  | 공격력 +{s5.items[i].AttackPower} | {s5.items[i].Information,-10}");
				}
				else
				{
					Console.WriteLine($"- {i + 1} {s5.items[i].Sign}{s5.items[i].Name,-6}  | 방어력 +{s5.items[i].DefensivePower} | {s5.items[i].Information,-10}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.Write(">>");

			while (true)
			{
				string? input = Console.ReadLine();
				switch (input)
				{
					case "1":
						{
							if (Display[0])
							{   //공격 아이템 장착 후 다른 공격 아이템을 장착 할 때
								if (!s5.items[0].equipped && s5.items[0].AttackPower > 0 && atk && AtkItem != null)
								{
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									s5.items[0].Sign = "[E]";
									s5.items[0].equipped = true;
									s5.player.AttackPower -= AtkItem.AttackPower;
									s5.AttackUP -= AtkItem.AttackPower;
									s5.player.AttackPower += s5.items[0].AttackPower;
									s5.AttackUP += s5.items[0].AttackPower;
									AtkItem = s5.items[0];
									InventoryManager();
								}
								// 처음 공격 아이템을 장착 했을 때
								else if (!s5.items[0].equipped && s5.items[0].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									s5.items[0].Sign = "[E]";
									s5.items[0].equipped = true;
									s5.AttackUP += s5.items[0].AttackPower;
									s5.player.AttackPower += s5.items[0].AttackPower;
									AtkItem = s5.items[0];
									InventoryManager();
								}
								// 방어 아이템 장착 후 다른 방어 아이템을 장착 할 때
								else if (!s5.items[0].equipped && s5.items[0].DefensivePower > 0 && def && DefItem != null)
								{
									DefItem.Sign = "";
									DefItem.equipped = false;
									s5.items[0].Sign = "[E]";
									s5.items[0].equipped = true;
									s5.player.DefensivePower -= DefItem.DefensivePower;
									s5.DefensiveUP -= DefItem.DefensivePower;
									s5.player.DefensivePower += s5.items[0].DefensivePower;
									s5.DefensiveUP += s5.items[0].DefensivePower;
									DefItem = s5.items[0];
									InventoryManager();
								}
								// 처음 방어 아이템을 장착 했을 떄
								else if (!s5.items[0].equipped && s5.items[0].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									s5.items[0].Sign = "[E]";
									s5.items[0].equipped = true;
									s5.DefensiveUP += s5.items[0].DefensivePower;
									s5.player.DefensivePower += s5.items[0].DefensivePower;
									DefItem = s5.items[0];
									InventoryManager();
								}			
								else
								{								
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									s5.items[0].Sign = "";
									s5.items[0].equipped = false;
									s5.DefensiveUP -= s5.items[0].DefensivePower;
									s5.AttackUP += s5.items[0].AttackPower;
									s5.player.DefensivePower -= s5.items[0].DefensivePower;
									s5.player.AttackPower -= s5.items[0].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다");
							}
							break;
						}
					case "2":
						{
							if (Display[1])
							{
								if (!s5.items[1].equipped && s5.items[1].AttackPower > 0 && atk && AtkItem != null)
								{
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									s5.items[1].Sign = "[E]";
									s5.items[1].equipped = true;
									s5.player.AttackPower -= AtkItem.AttackPower;
									s5.AttackUP -= AtkItem.AttackPower;
									s5.player.AttackPower += s5.items[1].AttackPower;
									s5.AttackUP += s5.items[1].AttackPower;
									AtkItem = s5.items[1];
									InventoryManager();
								}
								else if (!s5.items[1].equipped && s5.items[1].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									s5.items[1].Sign = "[E]";
									s5.items[1].equipped = true;
									s5.AttackUP += s5.items[1].AttackPower;
									s5.player.AttackPower += s5.items[1].AttackPower;
									AtkItem = s5.items[1];
									InventoryManager();
								}
								else if (!s5.items[1].equipped && s5.items[1].DefensivePower > 0 && def && DefItem != null)
								{
									DefItem.Sign = "";
									DefItem.equipped = false;
									s5.items[1].Sign = "[E]";
									s5.items[1].equipped = true;
									s5.player.DefensivePower -= DefItem.DefensivePower;
									s5.DefensiveUP -= DefItem.DefensivePower;
									s5.player.DefensivePower += s5.items[1].DefensivePower;
									s5.DefensiveUP += s5.items[1].DefensivePower;
									DefItem = s5.items[1];
									InventoryManager();
								}

								else if (!s5.items[1].equipped && s5.items[1].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									s5.items[1].Sign = "[E]";
									s5.items[1].equipped = true;
									s5.DefensiveUP += s5.items[1].DefensivePower;
									s5.player.DefensivePower += s5.items[1].DefensivePower;
									DefItem = s5.items[1];
									InventoryManager();
								}
								
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									s5.items[1].Sign = "";
									s5.items[1].equipped = false;
									s5.DefensiveUP -= s5.items[1].DefensivePower;
									s5.AttackUP -= s5.items[1].AttackPower;
									s5.player.DefensivePower -= s5.items[1].DefensivePower;
									s5.player.AttackPower -= s5.items[1].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "3":
						{
							if (Display[2])
							{
								if (!s5.items[2].equipped && s5.items[2].AttackPower > 0 && atk && AtkItem != null)
								{
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									s5.items[2].Sign = "[E]";
									s5.items[2].equipped = true;
									s5.player.AttackPower -= AtkItem.AttackPower;
									s5.AttackUP -= AtkItem.AttackPower;
									s5.player.AttackPower += s5.items[2].AttackPower;
									s5.AttackUP += s5.items[2].AttackPower;
									AtkItem = s5.items[2];
									InventoryManager();
								}
								else if (!s5.items[2].equipped && s5.items[2].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									s5.items[2].Sign = "[E]";
									s5.items[2].equipped = true;
									s5.AttackUP += s5.items[2].AttackPower;
									s5.player.AttackPower += s5.items[2].AttackPower;
									AtkItem = s5.items[2];
									InventoryManager();
								}
								else if (!s5.items[2].equipped && s5.items[2].DefensivePower > 0 && def && DefItem != null)
								{
									DefItem.Sign = "";
									DefItem.equipped = false;
									s5.items[2].Sign = "[E]";
									s5.items[2].equipped = true;
									s5.player.DefensivePower -= DefItem.DefensivePower;
									s5.DefensiveUP -= DefItem.DefensivePower;
									s5.player.DefensivePower += s5.items[2].DefensivePower;
									s5.DefensiveUP += s5.items[2].DefensivePower;
									DefItem = s5.items[2];
									InventoryManager();
								}

								else if (!s5.items[2].equipped && s5.items[2].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									s5.items[2].Sign = "[E]";
									s5.items[2].equipped = true;
									s5.DefensiveUP += s5.items[2].DefensivePower;
									s5.player.DefensivePower += s5.items[2].DefensivePower;
									DefItem = s5.items[2];
									InventoryManager();
								}
								
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									s5.items[2].Sign = "";
									s5.items[2].equipped = false;
									s5.DefensiveUP -= s5.items[2].DefensivePower;
									s5.AttackUP -= s5.items[2].AttackPower;
									s5.player.DefensivePower -= s5.items[2].DefensivePower;
									s5.player.AttackPower -= s5.items[2].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "4":
						{
							if (Display[3])
							{
								if (!s5.items[3].equipped && s5.items[3].AttackPower > 0 && atk && AtkItem != null)
								{
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									s5.items[3].Sign = "[E]";
									s5.items[3].equipped = true;
									s5.player.AttackPower -= AtkItem.AttackPower;
									s5.AttackUP -= AtkItem.AttackPower;
									s5.player.AttackPower += s5.items[3].AttackPower;
									s5.AttackUP += s5.items[3].AttackPower;
									AtkItem = s5.items[3];
									InventoryManager();
								}
								else if (!s5.items[3].equipped && s5.items[3].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									s5.items[3].Sign = "[E]";
									s5.items[3].equipped = true;
									s5.AttackUP += s5.items[3].AttackPower;
									s5.player.AttackPower += s5.items[3].AttackPower;
									AtkItem = s5.items[3];
									InventoryManager();
								}
								else if (!s5.items[3].equipped && s5.items[3].DefensivePower > 0 && def && DefItem != null)
								{
									DefItem.Sign = "";
									DefItem.equipped = false;
									s5.items[3].Sign = "[E]";
									s5.items[3].equipped = true;
									s5.player.DefensivePower -= DefItem.DefensivePower;
									s5.DefensiveUP -= DefItem.DefensivePower;
									s5.player.DefensivePower += s5.items[3].DefensivePower;
									s5.DefensiveUP += s5.items[3].DefensivePower;
									DefItem = s5.items[3];
									InventoryManager();
								}

								else if (!s5.items[3].equipped && s5.items[3].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									s5.items[3].Sign = "[E]";
									s5.items[3].equipped = true;
									s5.DefensiveUP += s5.items[3].DefensivePower;
									s5.player.DefensivePower += s5.items[3].DefensivePower;
									DefItem = s5.items[3];
									InventoryManager();
								}
																
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									s5.items[3].Sign = "";
									s5.items[3].equipped = false;
									s5.DefensiveUP -= s5.items[3].DefensivePower;
									s5.AttackUP -= s5.items[3].AttackPower;
									s5.player.DefensivePower -= s5.items[3].DefensivePower;
									s5.player.AttackPower -= s5.items[3].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "5":
						{
							if (Display[4])
							{
								if (!s5.items[4].equipped && s5.items[4].AttackPower > 0 && atk && AtkItem != null)
								{
									AtkItem.Sign = "";
									AtkItem.equipped = false;
									s5.items[4].Sign = "[E]";
									s5.items[4].equipped = true;
									s5.player.AttackPower -= AtkItem.AttackPower;
									s5.AttackUP -= AtkItem.AttackPower;
									s5.player.AttackPower += s5.items[4].AttackPower;
									s5.AttackUP += s5.items[4].AttackPower;
									AtkItem = s5.items[4];
									InventoryManager();
								}
								else if (!s5.items[4].equipped && s5.items[4].AttackPower > 0 && !atk && AtkItem == null)
								{
									atk = true;
									s5.items[4].Sign = "[E]";
									s5.items[4].equipped = true;
									s5.AttackUP += s5.items[4].AttackPower;
									s5.player.AttackPower += s5.items[4].AttackPower;
									AtkItem = s5.items[4];
									InventoryManager();
								}
								else if (!s5.items[4].equipped && s5.items[4].DefensivePower > 0 && def && DefItem != null)
								{
									DefItem.Sign = "";
									DefItem.equipped = false;
									s5.items[4].Sign = "[E]";
									s5.items[4].equipped = true;
									s5.player.DefensivePower -= DefItem.DefensivePower;
									s5.DefensiveUP -= DefItem.DefensivePower;
									s5.player.DefensivePower += s5.items[4].DefensivePower;
									s5.DefensiveUP += s5.items[4].DefensivePower;
									DefItem = s5.items[4];
									InventoryManager();
								}

								else if (!s5.items[4].equipped && s5.items[4].DefensivePower > 0 && !def && DefItem == null)
								{
									def = true;
									s5.items[4].Sign = "[E]";
									s5.items[4].equipped = true;
									s5.DefensiveUP += s5.items[4].DefensivePower;
									s5.player.DefensivePower += s5.items[4].DefensivePower;
									DefItem = s5.items[4];
									InventoryManager();
								}
														
								else
								{
									DefItem = null;
									def = false;
									AtkItem = null;
									atk = false;
									s5.items[4].Sign = "";
									s5.items[4].equipped = false;
									s5.DefensiveUP -= s5.items[4].DefensivePower;
									s5.AttackUP -= s5.items[4].AttackPower;
									s5.player.DefensivePower -= s5.items[4].DefensivePower;
									s5.player.AttackPower -= s5.items[4].AttackPower;
									InventoryManager();
								}
							}
							else
							{
								Console.WriteLine("잘못된 입력입니다.");
							}
							break;
						}
					case "0": InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}
		public void AttackPowerInventorySort()
		{
			s5.items.Sort((x, y) =>
			{
				return y.AttackPower.CompareTo(x.AttackPower);
			});
		}

		public void DefensivePowerInventorySort()
		{
			s5.items.Sort((x, y) =>
			{
				return y.DefensivePower.CompareTo(x.DefensivePower);
			});
		}
	}
}
