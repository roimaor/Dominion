using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Victory_cards
{
	class GardensCard : VictoryCard
	{
		public GardensCard() : base("Gardens", 4, null, 0)
		{

		}
		public override Card cloneCard()
		{
			return new GardensCard();
		}

		public override void specialEffect()
		{
			return;
		}

		public override int vpsWorth()
		{
			int totalCardsSum = CardOwner.CardsPiles.Hand.Count + CardOwner.CardsPiles.DiscardPile.Count +
				CardOwner.CardsPiles.Deck.Count + CardOwner.CardsPiles.InPlay.Count;
			return (totalCardsSum / 10);
		}
	}
}
