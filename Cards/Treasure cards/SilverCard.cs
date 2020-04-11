using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Treasure_cards
{
    public class SilverCard : TreasureCard
    {
        public SilverCard() : base("Silver", 3,null,2)
        {

        }

        public override Card cloneCard()
        {
            return new SilverCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
