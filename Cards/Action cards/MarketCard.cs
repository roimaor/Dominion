using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class MarketCard : ActionCard
    { 
        public MarketCard() : base("Market", 5,null,1,1,1,1)
        {

        }
        public override Card cloneCard()
        {
            return new MarketCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
