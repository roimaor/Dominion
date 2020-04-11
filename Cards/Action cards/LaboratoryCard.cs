using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class LaboratoryCard : ActionCard
    { 
        public LaboratoryCard() : base("Laboratory", 5,null,1,2,0,0)
        {

        }
        public override Card cloneCard()
        {
            return new LaboratoryCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
