using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class PoacherCard : ActionCard
    { 
        public PoacherCard() : base("Poacher", 4,null,1,1,0,1)
        {

        }
        public override Card cloneCard()
        {
            return new PoacherCard();
        }

        public override void specialEffect()
        {
            List<string> cardsNames = CardOwner.GameBoard.globalCardsPiles.getCardsNames();
            int emptyPilesCounter = 0;
            foreach (string cardName in cardsNames)
            {
                if (CardOwner.GameBoard.globalCardsPiles.getCardsPile(cardName).isEmpty())
                {
                    emptyPilesCounter++;
                }
            }

            for(int i = 0; i < emptyPilesCounter; i++)
            {
                CardOwner.GameBoard.clearConsoleButKeepPlayerTurn(CardOwner);
                Console.WriteLine("Discard " + (emptyPilesCounter - i) + " card.");
                Console.WriteLine("Choose what card you want to discard:");
                int counter = 0;
                foreach (Card card in CardOwner.CardsPiles.Hand)
                {
                    Console.Write("[" + (counter++) + "] - ");
                    CardsUtilities.printCardName(card);
                }
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                CardOwner.CardsPiles.moveCardFromHandToDiscardPile(playerChoice);
            }
        }
    }
}
