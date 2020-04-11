using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dominion.Cards
{
	class CardsUtilities
	{
		public static int comparison(Card x, Card y)
		{
			int xsum = evaluateCard(x);
			int ysum = evaluateCard(y);
			if (xsum == ysum)
				return 0;

			return (xsum > ysum) ? 1 : -1;

		}

		private static int evaluateCard(Card x)
		{
			int sum = 0;
			sum += (x is ActionCard) ? 100 : 0;
			sum += (x is TreasureCard) ? 200 : 0;
			sum += (x is VictoryCard) ? 300 : 0;
			sum += x.Cost;

			return sum;
		}
		public static void printCardName(Card x)
		{
			if (x is ActionCard)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
			}
			else if (x is TreasureCard)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			Console.WriteLine(x.Name);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public static void printCardName(CardPile x)
		{
			if (x.CardTemplate is ActionCard)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
			}
			else if (x.CardTemplate is TreasureCard)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
			string tabs = "\t\t";
			if (x.CardTemplate.Name.Length < 8)
			{
				tabs += "\t";
			}
			Console.WriteLine(x.CardTemplate.Name + tabs +"Cost: " + x.CardTemplate.Cost +"\t("+ x.size() + ")");
			Console.ForegroundColor = ConsoleColor.Gray;
		}
	}
}
