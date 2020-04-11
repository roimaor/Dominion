using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Victory_cards
{
	class EstateCard : VictoryCard
	{
		public EstateCard() : base("Estate", 2, null, 1)
		{

		}
		public override Card cloneCard()
		{
			return new EstateCard();
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
