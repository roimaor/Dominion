using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Victory_cards
{
	class DuchyCard : VictoryCard
	{
		public DuchyCard() : base("Duchy", 5, null, 3)
		{

		}
		public override Card cloneCard()
		{
			return new DuchyCard();
		}

		public override void specialEffect()
		{
			return;
		}

		public override int vpsWorth()
		{
			return Vps;
		}
	}
}
