using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
	public abstract class ActionCard : Card
	{
		private int extraActions;
		private int extraCards;
		private int extraBuys;
		private int extraMoney;

		public ActionCard(string name, int cost, Player cardOwner,
			int extraActions, int extraCards, int extraBuys, int extraMoney) : base(name, cost, cardOwner)
		{
			this.ExtraActions = extraActions;
			this.ExtraCards = extraCards;
			this.ExtraBuys = extraBuys;
			this.ExtraMoney = extraMoney;
		}

		public int ExtraActions { get { return extraActions; } set { extraActions = value; } }
		public int ExtraCards { get { return extraCards; } set { extraCards = value; } }
		public int ExtraBuys { get { return extraBuys; } set { extraBuys = value; } }
		public int ExtraMoney { get { return extraMoney; } set { extraMoney = value; } }

		public override void playCard()
		{
			CardOwner.increaseActionsCounter(extraActions);
			CardOwner.drawCardsFromDeck(extraCards);
			CardOwner.increaseBuysCounter(extraBuys);
			CardOwner.increaseMoneyCounter(extraMoney);
			specialEffect();
		}
	}
}
