﻿using System.Reflection.Emit;
using System;

namespace ConsoleRPG
{
	// 혹시 몰라서 interface로 구현, 바로 클래스로 구현 가능
	public interface Character
	{
		int Level { get; set; }
		string Name { get; }
		string chad { get; }
		int AttackPower { get; set; }
		int DefensivePower { get; set; }
		int Health { get; set; }
		int Gold { get; set; }
	}

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

	}
	public class State : Player
	{
		public State(string Name, string chad) : base(Name, chad) { }

	}

	public interface Item
	{
		string Name { get; set; }
		int DefensivePower { get; set; }

		int AttackPower { get; set; }
		string Information { get; set; }
		int Price { get; set; }
		bool I_Exist { get; set; }
	}

	public class IronArmor : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }
		public IronArmor(string Name, int DefensivePower, string Information, bool I_Exist) 
		{ 
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
			AttackPower = 0;
			Price = 600;
			this.I_Exist = I_Exist;
		}
	}

	public class IronRing : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }


		public IronRing(string Name, int DefensivePower, string Information)
		{
			this.Name = Name;
			this.DefensivePower = DefensivePower;
			this.Information = Information;
			AttackPower = 0;
			Price = 400;
			I_Exist = false;
		}
	}

	public class OldSword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }

		public OldSword(string Name, int AttackPower, string Information, bool I_Exist)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 200;
			this.I_Exist = I_Exist;
		}
	}
	public class Sword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }

		public Sword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 800;
			I_Exist = false;
		}
	}

	public class GoldSword : Item
	{
		public string Name { get; set; }
		public int DefensivePower { get; set; }
		public string Information { get; set; }
		public int AttackPower { get; set; }
		public int Price { get; set; }
		public bool I_Exist { get; set; }

		public GoldSword(string Name, int AttackPower, string Information)
		{
			this.Name = Name;
			this.AttackPower = AttackPower;
			this.Information = Information;
			DefensivePower = 0;
			Price = 1300;
			I_Exist = false;
		}
	}

	public class DisplayInfor
	{
		public bool OnChk = false;
		public string Equip_Sign = "";
		public bool Make = false;
		public DisplayInfor(bool onChk, string equip_Sign, bool make)
		{
			OnChk = onChk;
			Equip_Sign = equip_Sign;
			Make = make;	
		}
	}

	public class Start
	{
		bool[] storeItem_chk = new bool[5];
		DisplayInfor[] Display = new DisplayInfor[5];
		bool DisplayArr_chk = false;
		int AttackUP = 0;
		int DefensiveUP = 0;
		string Display1 = "";
		bool chk1 = false;
		string Display2 = "";
		bool chk2 = false;
		string Display3 = "";
		bool chk3 = false;
		string Display4 = "";
		bool chk4 = false;
		string Display5 = "";
		bool chk5 = false;
		private Character player;
		private List<Item> items;
		private List<Item> store_Items;
		public Start(Player player, List<Item>items, List<Item>store_Items)
		{
			this.player = player;
			this.items = items;
			this.store_Items = store_Items;
		}

		public void GameStart()
		{
			Console.Clear();
			Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
			Console.WriteLine("이곳에서 던전을 들어가기 전 활동을 할 수 있습니다.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1. 상태 보기");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("2. 인벤토리");
			Console.ResetColor();
			Console.WriteLine("3. 상점");
			Console.WriteLine();

			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
		
			while (true) {
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "1": StateOn(); break;
					case "2": InventoryOn(); break;
					case "3": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void Store()
		{
			Console.Clear();
			Console.WriteLine("상점");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for(int i = 0; i < store_Items.Count; i++)
			{
				if (store_Items[i].DefensivePower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (store_Items[i].AttackPower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | 소지 중");
					}
				}
			}
			Console.WriteLine();
			Console.WriteLine("1. 아이템 구매");
			Console.WriteLine("2. 아이템 판매");
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>");
			string input = Console.ReadLine();

			switch (input)
			{
				case "1": StorePurchase(); break;
				case "2": StoreSell(); break;
				case "0": GameStart(); break;
			}
		}
		public void StoreSell()
		{
			Console.Clear();
			Console.WriteLine("상점 - 아이템 판매");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");

			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {items[i].Name,-6}  | 공격력 +{items[i].AttackPower} | {items[i].Information,-10} ");
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
					case "1":
						if (storeItem_chk[0])
						{
							if (!store_Items[0].I_Exist && player.Gold >= store_Items[0].Price)
							{
								store_Items[0].I_Exist = true;
								player.Gold -= store_Items[0].Price;
								items.Add(store_Items[0]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "2":
						if (storeItem_chk[1])
						{
							if (!store_Items[1].I_Exist && player.Gold >= store_Items[1].Price)
							{
								store_Items[1].I_Exist = true;
								player.Gold -= store_Items[1].Price;
								items.Add(store_Items[1]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "3":
						if (storeItem_chk[2])
						{
							if (!store_Items[2].I_Exist && player.Gold >= store_Items[2].Price)
							{
								store_Items[2].I_Exist = true;
								player.Gold -= store_Items[2].Price;
								items.Add(store_Items[2]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "4":
						if (storeItem_chk[3])
						{
							if (!store_Items[3].I_Exist && player.Gold >= store_Items[3].Price)
							{
								store_Items[3].I_Exist = true;
								player.Gold -= store_Items[3].Price;
								items.Add(store_Items[3]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "5":
						if (storeItem_chk[4])
						{
							if (!store_Items[4].I_Exist && player.Gold >= store_Items[4].Price)
							{
								store_Items[4].I_Exist = true;
								player.Gold -= store_Items[4].Price;
								items.Add(store_Items[4]);
								StorePurchase();
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;

					case "0": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
				}
			}
		}
		public void StorePurchase()
		{
			Console.Clear();
			Console.WriteLine("상점 - 아이템 구매");
			Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
			Console.WriteLine();
			Console.WriteLine("[보유 골드]");
			Console.WriteLine($"{player.Gold} G");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < store_Items.Count; i++)
			{
				storeItem_chk[i] = true;
				if (store_Items[i].DefensivePower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 공격력 +{store_Items[i].AttackPower} | {store_Items[i].Information,-10} | 소지 중");
					}

				}
				else if (store_Items[i].AttackPower == 0)
				{
					if (!store_Items[i].I_Exist)
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | {store_Items[i].Price} G");
					}
					else
					{
						Console.WriteLine($"- {i + 1} {store_Items[i].Name,-6}  | 방어력 +{store_Items[i].DefensivePower} | {store_Items[i].Information,-10} | 소지 중");
					}
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
					case "1":
						if (storeItem_chk[0])
						{
							if (!store_Items[0].I_Exist && player.Gold >= store_Items[0].Price)
							{
								store_Items[0].I_Exist = true;
								player.Gold -= store_Items[0].Price;
								items.Add(store_Items[0]);								
								Console.WriteLine("구매를 완료했습니다.");
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "2":
						if (storeItem_chk[1])
						{
							if (!store_Items[1].I_Exist && player.Gold >= store_Items[1].Price)
							{
								store_Items[1].I_Exist = true;
								player.Gold -= store_Items[1].Price;
								items.Add(store_Items[1]);
								Console.WriteLine("구매를 완료했습니다.");
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "3":
						if (storeItem_chk[2])
						{
							if (!store_Items[2].I_Exist && player.Gold >= store_Items[2].Price)
							{
								store_Items[2].I_Exist = true;
								player.Gold -= store_Items[2].Price;
								items.Add(store_Items[2]);
								Console.WriteLine("구매를 완료했습니다.");
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "4":
						if (storeItem_chk[3])
						{
							if (!store_Items[3].I_Exist && player.Gold >= store_Items[3].Price)
							{
								store_Items[3].I_Exist = true;
								player.Gold -= store_Items[3].Price;
								items.Add(store_Items[3]);
								Console.WriteLine("구매를 완료했습니다.");
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;
					case "5":
						if (storeItem_chk[4])
						{
							if (!store_Items[4].I_Exist && player.Gold >= store_Items[4].Price)
							{
								store_Items[4].I_Exist = true;
								player.Gold -= store_Items[4].Price;
								items.Add(store_Items[4]);
								Console.WriteLine("구매를 완료했습니다.");
							}
							else
							{
								Console.WriteLine("금액이 부족하거나 이미 소지 중인 아이템입니다.");
							}
						}
						else
						{
							Console.WriteLine("잘못된 입력입니다.");
						}
						break;

					case "0": Store(); break;
					default: Console.WriteLine("잘못된 입력입니다."); break;
				}
			}
		}
		public void DisArrMake() //디스플레이 배열마다 인자 생성
		{
			for(int i = 0; i < Display.Length; i++)
			{
				Display[i] = new DisplayInfor(false, "", false);
			}
		}
		public void InventoryOn()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for(int i = 0; i < items.Count; i++)
			{
				
				if (!DisplayArr_chk)
				{
					DisArrMake();
					DisplayArr_chk = true;
				}
				//현재 디스플레이어 위치에 값이 있나 없나 판단
				Display[i].Make = true;
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {Display[i].Equip_Sign}{items[i].Name, -6}  | 공격력 +{items[i].AttackPower} | {items[i].Information, -10}");
				}
				else
				{
					Console.WriteLine($"- {Display[i].Equip_Sign}{items[i].Name, -6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information, -10}");
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
				string ?input = Console.ReadLine();
				switch (input)
				{
					case "1": InventoryManager(); break;
					case "0": GameStart(); break;
					case "2": AttackPowerInventorySort(); InventoryOn(); break;
					case "3": DefensivePowerInventorySort(); InventoryOn(); break;
					default: Console.WriteLine("잘못된 입력입니다"); break;
				}
			}
		}

		public void InventoryManager()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("인벤토리 - 장착 관리");
			Console.ResetColor();
			Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
			Console.WriteLine();
			Console.WriteLine("[아이템 목록]");
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].DefensivePower == 0)
				{
					Console.WriteLine($"- {i + 1} {Display[i].Equip_Sign}{items[i].Name, -6}  | 공격력 +{items[i].AttackPower} | {items[i].Information, -10}");
				}
				else
				{
					Console.WriteLine($"- {i + 1} {Display[i].Equip_Sign}{items[i].Name, -6}  | 방어력 +{items[i].DefensivePower} | {items[i].Information, -10}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요");
			Console.Write(">>");
			while (true) { 
			string ?input = Console.ReadLine();
				switch (input)
				{
					case "1":
						{
							if (Display[0].Make)
							{
								if (!Display[0].OnChk)
								{
									Display[0].Equip_Sign = "[E]";
									Display[0].OnChk = true;
									DefensiveUP += items[0].DefensivePower;
									AttackUP += items[0].AttackPower;
									player.DefensivePower += items[0].DefensivePower;
									player.AttackPower += items[0].AttackPower;
									InventoryManager();
								}
								else
								{
									Display[0].Equip_Sign = "";
									Display[0].OnChk = false;
									DefensiveUP -= items[0].DefensivePower;
									AttackUP += items[0].AttackPower;
									player.DefensivePower -= items[0].DefensivePower;
									player.AttackPower -= items[0].AttackPower;
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
							if (Display[1].Make)
							{
								if (!Display[1].OnChk)
								{
									Display[1].Equip_Sign = "[E]";
									Display[1].OnChk = true;
									DefensiveUP += items[1].DefensivePower;
									AttackUP += items[1].AttackPower;
									player.DefensivePower += items[1].DefensivePower;
									player.AttackPower += items[1].AttackPower;
									InventoryManager();
								}
								else
								{
									Display[1].Equip_Sign = "";
									Display[1].OnChk = false;
									DefensiveUP -= items[1].DefensivePower;
									AttackUP -= items[1].AttackPower;
									player.DefensivePower -= items[1].DefensivePower;
									player.AttackPower -= items[1].AttackPower;
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
							if (Display[2].Make)
							{
								if (!Display[2].OnChk)
								{
									Display[2].Equip_Sign = "[E]";
									Display[2].OnChk = true;
									DefensiveUP += items[2].DefensivePower;
									AttackUP += items[2].AttackPower;
									player.DefensivePower += items[2].DefensivePower;
									player.AttackPower += items[2].AttackPower;
									InventoryManager();
								}
								else
								{
									Display[2].Equip_Sign = "";
									Display[2].OnChk = false;
									DefensiveUP -= items[2].DefensivePower;
									AttackUP -= items[2].AttackPower;
									player.DefensivePower -= items[2].DefensivePower;
									player.AttackPower -= items[2].AttackPower;
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
							if (Display[3].Make)
							{
								if (!Display[3].OnChk)
								{
									Display[3].Equip_Sign = "[E]";
									Display[3].OnChk = true;
									DefensiveUP += items[3].DefensivePower;
									AttackUP += items[3].AttackPower;
									player.DefensivePower += items[3].DefensivePower;
									player.AttackPower += items[3].AttackPower;
									InventoryManager();
								}
								else
								{
									Display[3].Equip_Sign = "";
									Display[3].OnChk = false;
									DefensiveUP -= items[3].DefensivePower;
									AttackUP -= items[3].AttackPower;
									player.DefensivePower -= items[3].DefensivePower;
									player.AttackPower -= items[3].AttackPower;
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
							if (Display[4].Make)
							{
								if (!Display[4].OnChk)
								{
									Display[4].Equip_Sign = "[E]";
									Display[4].OnChk = true;
									DefensiveUP += items[4].DefensivePower;
									AttackUP += items[4].AttackPower;
									player.DefensivePower += items[4].DefensivePower;
									player.AttackPower += items[4].AttackPower;
									InventoryManager();
								}
								else
								{
									Display[4].Equip_Sign = "";
									Display[4].OnChk = false;
									DefensiveUP -= items[4].DefensivePower;
									AttackUP -= items[4].AttackPower;
									player.DefensivePower -= items[4].DefensivePower;
									player.AttackPower -= items[0].AttackPower;
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
			items.Sort((x, y) =>
			{
				return y.AttackPower.CompareTo(x.AttackPower);
			});
		}

		public void DefensivePowerInventorySort()
		{
			items.Sort((x, y) =>
			{
				return y.DefensivePower.CompareTo(x.DefensivePower);
			});
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
				string ?input = Console.ReadLine();
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
			  new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", true),
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.", true),
			  new Sword("검", 4, "튼튼한 검입니다."),
			  new IronRing("철반지", 3, "은으로 만들어진 반지입니다.")
			};

			List<Item>items = new List<Item> 
			{ new IronArmor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", true), 
			  new OldSword("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.", true),
			  };

			Player player = new State("Sungho" , "전사");
			Start start = new Start(player, items, store_Items);

			start.GameStart();			
		}
	}
}