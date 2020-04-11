using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Victory_cards
{
	class CurseCard : VictoryCard
	{
		public CurseCard() : base("Curse", 0, null, -1)
		{

		}
		public override Card cloneCard()
		{
			return new CurseCard();
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
