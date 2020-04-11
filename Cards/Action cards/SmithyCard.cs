using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class SmithyCard : ActionCard
    { 
        public SmithyCard() : base("Smithy", 4,null,0,3,0,0)
        {

        }
        public override Card cloneCard()
        {
            return new SmithyCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
