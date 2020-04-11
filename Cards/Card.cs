using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
	public abstract class Card
	{
		// This is a card class
		public delegate void SpecialEffect();

		private string name;
		private int cost;
		public Player cardOwner;

		public Card(string name, int cost, Player cardOwner)
		{
			this.Name = name;
			this.Cost = cost;
			this.CardOwner = cardOwner;
		}

		abstract public void playCard();

		abstract public Card cloneCard();

		public string Name { get { return name; } set { name = value; } }
		public int Cost { get { return cost; } set { cost = value; } }

		public Player CardOwner { get { return cardOwner; } set { cardOwner = value; } }
		abstract public void specialEffect();
	}
}
