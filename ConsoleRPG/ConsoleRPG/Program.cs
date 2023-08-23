using System.Reflection.Emit;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace ConsoleRPG
{
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

