using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
	public abstract class TreasureCard : Card
	{
		private int money;

		public TreasureCard(string name, int cost, Player cardOwner, int money) : base(name, cost, cardOwner)
		{
			this.Money = money;
		}

		public int Money { get { return money; } set { money = value; } }

		public override void playCard()
		{
			CardOwner.increaseMoneyCounter(money);
			specialEffect();
		}
	}
}
