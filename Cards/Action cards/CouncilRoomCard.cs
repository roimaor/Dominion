using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class CouncilRoomCard : ActionCard
    {
        public CouncilRoomCard() : base("Cuncil Room", 5, null, 0, 4, 1, 0)
        {

        }
        public override Card cloneCard()
        {
            return new CouncilRoomCard();
        }

        public override void specialEffect()
        {
            foreach(Player player in CardOwner.GameBoard.Players)
            {
                if(player != CardOwner)
                {
                    player.drawCardsFromDeck(1);
                }
            }
        }
    }
}
