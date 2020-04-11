using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class WitchCard : ActionCard
    { 
        public WitchCard() : base("Witch", 5,null,0,2,0,0)
        {

        }
        public override Card cloneCard()
        {
            return new WitchCard();
        }

        public override void specialEffect()
        {
            int currentPlayerIndex = 0;
            int num_of_players = CardOwner.GameBoard.Players.Length;

            foreach (Player player in CardOwner.GameBoard.Players)
            {
                if (player == CardOwner)
                {
                    break;
                }
                currentPlayerIndex++;
            }

            int playerIndex = (currentPlayerIndex + 1) % num_of_players;

            while(playerIndex != currentPlayerIndex)
            {
                Player player = CardOwner.GameBoard.Players[playerIndex];
                player.CardsPiles.moveCardFromGlobalPilesToPlayerDiscardPile("Curse");
                playerIndex = (playerIndex + 1) % num_of_players;
            }
        }
    }
}
