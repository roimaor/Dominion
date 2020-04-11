using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominion.Cards;

namespace Dominion
{
	public class PlayerCardsPiles
	{
		private const int INITIAL_NUM_OF_COPPERS = 7;
		private const int INITIAL_NUM_OF_ESTATES = 3;
		public const int INITIAL_HAND_SIZE = 5;

		private DominionGame gameBoard;
		Player cardsPilesOwner;
		private List<Card> hand;
		private Stack<Card> deck;
		private Stack<Card> discardPile;
		private List<Card> inPlay;
		private Random rnd;

		public PlayerCardsPiles(DominionGame gameBoard, Player cardsPilesOwner)
		{
			this.gameBoard = gameBoard;
			this.cardsPilesOwner = cardsPilesOwner;
			hand = new List<Card>();
			deck = new Stack<Card>();
			discardPile = new Stack<Card>();
			inPlay = new List<Card>();
			rnd = new Random();
			init();
		}

		public List<Card> Hand { get { return hand; } }
		public Stack<Card> Deck { get { return deck; } }
		public Stack<Card> DiscardPile { get { return discardPile; } }
		public List<Card> InPlay { get { return inPlay; } }

		public Player CardsPilesOwner { get { return cardsPilesOwner; } }

		public void init()
		{
			// Each player draws coppers and estates
			for (int i = 0; i < INITIAL_NUM_OF_COPPERS; i++)
			{
				moveCardFromGlobalPilesToPlayerDeck("Copper");
			}
			for (int i = 0; i < INITIAL_NUM_OF_ESTATES; i++)
			{
				moveCardFromGlobalPilesToPlayerDeck("Estate");
			}

			shuffleDeck();
			drawCardsFromDeck(INITIAL_HAND_SIZE);
		}

		public void addCardToPlayerHand(Card card)
		{
			hand.Add(card);
			hand.Sort(CardsUtilities.comparison);
		}

		public void addCardToPlayerDeck(Card card)
		{
			deck.Push(card);
		}

		public void moveCardFromGlobalPilesToPlayerDiscardPile(string cardName)
		{
			if (!gameBoard.globalCardsPiles.getCardsPile(cardName).isEmpty())
			{
				addCardToPlayerDiscardPile(gameBoard.globalCardsPiles.getCardsPile(cardName).drawCard());
				DiscardPile.Peek().CardOwner = cardsPilesOwner;
			}
		}

		public void moveCardFromGlobalPilesToPlayerDeck(string cardName)
		{
			if (!gameBoard.globalCardsPiles.getCardsPile(cardName).isEmpty())
			{
				addCardToPlayerDeck(gameBoard.globalCardsPiles.getCardsPile(cardName).drawCard());
				Deck.Peek().CardOwner = cardsPilesOwner;
			}
		}


		public void addCardToPlayerDiscardPile(Card card)
		{
			discardPile.Push(card);
		}

		public void addCardToPlayerInPlay(Card card)
		{
			inPlay.Add(card);
		}

		public int countActionCardsInHand()
		{
			int sum = 0;

			foreach (Card card in Hand)
			{
				if (card is ActionCard)
				{
					sum++;
				}
			}

			return sum;
		}

		public int countTreasureCardsInHand()
		{
			int sum = 0;

			foreach (Card card in Hand)
			{
				if (card is TreasureCard)
				{
					sum++;
				}
			}

			return sum;
		}

		public void drawCardsFromDeck(int num)
		{
			if (deck.Count < num)
			{
				moveDiscardPileCardsToDeckAndShuffle();
			}
			num = Math.Min(num, deck.Count);

			for (int i = 0; i < num; i++)
			{
				addCardToPlayerHand(deck.Pop());
			}
		}

		private void moveDiscardPileCardsToDeckAndShuffle()
		{
			while (discardPile.Count > 0)
			{
				deck.Push(discardPile.Pop());
			}
			this.shuffleDeck();
		}

		private void shuffleDeck()
		{
			var values = deck.ToArray();
			deck.Clear();
			foreach (var value in values.OrderBy(x => rnd.Next()))
			{
				deck.Push((Card)value);
			}
				
		}

		public void moveHandToDiscardPile()
		{
			while (hand.Count > 0)
			{
				addCardToPlayerDiscardPile(hand[hand.Count - 1]);
				hand.RemoveAt(hand.Count - 1);
			}
		}

		public void moveInPlayerToDiscardPile()
		{
			while (inPlay.Count > 0)
			{
				addCardToPlayerDiscardPile(inPlay[inPlay.Count - 1]);
				inPlay.RemoveAt(inPlay.Count - 1);
			}
		}

		public void moveCardFromHandToInPlay(int index)
		{
			addCardToPlayerInPlay(hand[index]);
			hand.RemoveAt(index);
		}

		public void moveCardFromHandToDiscardPile(int index)
		{
			addCardToPlayerDiscardPile(hand[index]);
			hand.RemoveAt(index);
		}

		public void moveAllPlayerCardsToHisHandAfterGameEnds()
		{
			while (discardPile.Count > 0)
			{
			   	addCardToPlayerHand(discardPile.Pop());
			}
			while (deck.Count > 0)
			{
				addCardToPlayerHand(deck.Pop());
			}
		}

		public void playNthActionCard(int n)
		{
			int counter = 0;
			foreach (Card card in Hand)
			{
				if (card is ActionCard)
				{
					n--;
					if (n == 0)
					{
						moveCardFromHandToInPlay(counter);
						card.playCard();
						card.CardOwner.increaseActionsCounter(-1);
						break;
					}
				}
				counter++;
			}
		}

		public void buyNthCardPlayerCanBuy(int n)
		{
			List<string> cardsNames = gameBoard.globalCardsPiles.getCardsNames();
			foreach (string cardName in cardsNames)
			{
				if (gameBoard.globalCardsPiles.getCardsPile(cardName).CardTemplate.Cost <= CardsPilesOwner.MoneyCounter
					&& gameBoard.globalCardsPiles.getCardsPile(cardName).size() > 0)
				{
					n--;
					if (n == 0)
					{
						moveCardFromGlobalPilesToPlayerDiscardPile(cardName);
						CardsPilesOwner.increaseBuysCounter(-1);
						CardsPilesOwner.increaseMoneyCounter(-1 * gameBoard.globalCardsPiles.getCardsPile(cardName).CardTemplate.Cost);
						break;
					}
				}
			}
		}

		public void playNthTreasureCard(int n)
		{
			int counter = 0;
			foreach (Card card in Hand)
			{
				if (card is TreasureCard)
				{
					n--;
					if (n == 0)
					{
						card.playCard();
						moveCardFromHandToInPlay(counter);
						break;
					}
				}
				counter++;
			}
		}

		public void playAllTreasureCards()
		{
			for(int i = 0; i < Hand.Count; i++)
			{
				Card card = Hand[i];
				if (card is TreasureCard)
				{
					card.playCard();
					moveCardFromHandToInPlay(i--);
				}
			}
		}

	}
}
