using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class FestivalCard : ActionCard
    { 
        public FestivalCard() : base("Festival",5,null,2,0,1,2)
        {

        }
        public override Card cloneCard()
        {
            return new FestivalCard();
        }

        public override void specialEffect()
        {
            return;
        }
    }
}
