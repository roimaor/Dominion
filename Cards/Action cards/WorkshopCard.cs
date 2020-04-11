using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion.Cards.Action_cards
{
    public class WorkshopCard : ActionCard
    { 
        public WorkshopCard() : base("Workshop", 3,null,0,0,0,0)
        {

        }
        public override Card cloneCard()
        {
            return new WorkshopCard();
        }

        public override void specialEffect()
        {
			int counter = 0;
			List<string> cardsPlayerCanBuy = new List<string>();
			//CardOwner.GameBoard.clearConsoleButKeepPlayerTurn(CardOwner);
			Console.WriteLine("Gain a card costing up to 4:");
			List<string> cardsNames = CardOwner.GameBoard.globalCardsPiles.getCardsNames();
			foreach (string cardName in cardsNames)
			{
				if (CardOwner.GameBoard.globalCardsPiles.getCardsPile(cardName).CardTemplate.Cost <= 4
					&& CardOwner.GameBoard.globalCardsPiles.getCardsPile(cardName).size() > 0)
				{
					cardsPlayerCanBuy.Add(cardName);
					Console.Write("[" + (counter++) + "] - ");
				}
				Console.Write("\t");
				CardsUtilities.printCardName(CardOwner.GameBoard.globalCardsPiles.getCardsPile(cardName));
			}

			int playerChoice = Convert.ToInt32(Console.ReadLine());
			CardOwner.CardsPiles.moveCardFromGlobalPilesToPlayerDiscardPile(cardsPlayerCanBuy[playerChoice]);
		}
    }
}
