using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominion
{
	public class Player : IComparable<Player>
	{
		// This is a player class
		private string name;
		private int roundsPlayed;
		private int actionsCounter;
		private int buysCounter;
		private int moneyCounter;
		private DominionGame gameBoard;
		private PlayerCardsPiles cardsPiles;
		private int playerVps;

		public Player(string name, DominionGame gameBoard)
		{
			this.gameBoard = gameBoard;
			this.Name = name;
			this.roundsPlayed = 0;
			this.actionsCounter = 0;
			this.buysCounter = 0;
			this.moneyCounter = 0;
			this.playerVps = 0;

			cardsPiles = new PlayerCardsPiles(gameBoard,this);
		}

		public string Name { get { return this.name; } set { this.name = value; } }

		public DominionGame GameBoard {  get { return this.gameBoard; } }

		public int RoundsPlayed { get { return this.roundsPlayed; } }

		public int PlayerVps { get { return this.playerVps; } }
		public PlayerCardsPiles CardsPiles { get { return cardsPiles; }}

		public int ActionsCounter { get { return this.actionsCounter; } }
		public int BuysCounter { get { return this.buysCounter; } }

		public int MoneyCounter { get { return this.moneyCounter; } }

		public void incrementRoundsPlayed()
		{
			roundsPlayed++;
		}

		public void increaseActionsCounter(int extra)
		{
			actionsCounter += extra;
		}

		public void increaseBuysCounter(int extra)
		{
			buysCounter += extra;
		}

		public void increaseMoneyCounter(int extra)
		{
			moneyCounter += extra;
		}

		public void drawCardsFromDeck(int num)
		{
			cardsPiles.drawCardsFromDeck(num);
		}

		public void playCardFromHand(int index)
		{
			CardsPiles.InPlay.Add(cardsPiles.Hand[index]);
			cardsPiles.Hand[index].playCard();
			cardsPiles.Hand.RemoveAt(index);
		}

		public void countPlayerVpsWhenGameEnds()
		{
			playerVps = 0;

			CardsPiles.moveAllPlayerCardsToHisHandAfterGameEnds();

			foreach (Card card in cardsPiles.Hand)
			{
				if (card is VictoryCard)
				{
					playerVps += ((VictoryCard)card).vpsWorth();
				}
			}
		}

		public int CompareTo(Player other)
		{
			if (playerVps != other.playerVps)
			{
				return (playerVps > other.playerVps)? 1 : -1;
			}
			if (roundsPlayed != other.roundsPlayed)
			{
				return (roundsPlayed > other.roundsPlayed) ? 1 : -1;
			}
			return 0;
		}

		public void initPlayerNewRound()
		{
			incrementRoundsPlayed();
			actionsCounter = 1;
			buysCounter = 1;
			moneyCounter = 0;
		}

		public void finalizePlayerRound()
		{
			CardsPiles.moveHandToDiscardPile();
			CardsPiles.moveInPlayerToDiscardPile();
			drawCardsFromDeck(PlayerCardsPiles.INITIAL_HAND_SIZE);
		}
	}
}
