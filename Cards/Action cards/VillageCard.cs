using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class VillageCard : ActionCard
    { 
        public VillageCard() : base("Village", 3,null,2,1,0,0)
        {

        }
        public override Card cloneCard()
        {
            return new VillageCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
