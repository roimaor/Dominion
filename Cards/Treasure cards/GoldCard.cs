using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Treasure_cards
{
    public class GoldCard : TreasureCard
    {
        public GoldCard() : base("Gold", 6,null,3)
        {

        }

        public override Card cloneCard()
        {
            return new GoldCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
