using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Treasure_cards
{
    public class CopperCard : TreasureCard
    {
        public CopperCard() : base("Copper",0,null,1)
        {

        }

        public override Card cloneCard()
        {
            return new CopperCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
