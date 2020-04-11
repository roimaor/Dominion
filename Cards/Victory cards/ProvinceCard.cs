using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Victory_cards
{
	class ProvinceCard : VictoryCard
	{
		public ProvinceCard() : base("Province", 8, null, 6)
		{

		}
		public override Card cloneCard()
		{
			return new ProvinceCard();
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
