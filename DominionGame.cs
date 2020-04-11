using System;
using System.Collections.Generic;
using System.Text;
using Dominion.Cards;

namespace Dominion
{
	public class DominionGame
	{
		private int num_of_players;
		private const int MAX_EMPTY_PILES_THRESHOLD = 3;

		private GlobalCardsPiles _globalCardsPiles;
		private Player[] players;

		public DominionGame()
		{

			int num;
			do
			{
				Console.WriteLine("Please enter number of players [2-6]:");
				try
				{
					num = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception) { Console.WriteLine("Wrong format input!"); continue; }
				if (num >= 2 && num <= 6)
				{
					break;
				}
				Console.WriteLine("Invalid number of players!");
			} while (true);
			

			num_of_players = num;
			players = new Player[num_of_players];
		}

		public GlobalCardsPiles globalCardsPiles { get { return _globalCardsPiles; } }
		public Player[] Players { get { return players; } }

		public void start()
		{
			_globalCardsPiles = new GlobalCardsPiles(this);
			for (int i = 0; i < num_of_players; i++)
			{
				Console.WriteLine("Enter the name of player #" + (i + 1));
				players[i] = new Player(Console.ReadLine(), this);
			}

			int currentPlayerIndex = 0;

			while (!isGameOver())
			{
				Player currentPlayer = Players[currentPlayerIndex];
				currentPlayer.initPlayerNewRound();
				clearConsoleButKeepPlayerTurn(currentPlayer);

				//Action phase
				while (currentPlayer.ActionsCounter > 0 && currentPlayer.CardsPiles.countActionCardsInHand() > 0)
				{
					Console.WriteLine("Actions: " + currentPlayer.ActionsCounter + " / Buys: " +
						currentPlayer.BuysCounter + " / Total cards in hand: " + currentPlayer.CardsPiles.Hand.Count);
					Console.WriteLine("Choose what action card you want to play:");
					Console.Write("[0] - ");
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("End action phase");
					Console.ForegroundColor = ConsoleColor.Gray;
					int counter = 1;
					foreach (Card card in currentPlayer.CardsPiles.Hand)
					{
						if (card is ActionCard)
						{
							Console.Write("[" + (counter++) + "] - ");
						}
						CardsUtilities.printCardName(card);
					}
					int playerChoice = Convert.ToInt32(Console.ReadLine());
					if (playerChoice == 0)
						break;

					currentPlayer.CardsPiles.playNthActionCard(playerChoice);
					clearConsoleButKeepPlayerTurn(currentPlayer);
				}
				clearConsoleButKeepPlayerTurn(currentPlayer);
				//Buy phase
				while (currentPlayer.BuysCounter > 0)
				{
					Console.WriteLine("Actions: " + currentPlayer.ActionsCounter + " / Buys: " +
						currentPlayer.BuysCounter + " / Total cards in hand: " + currentPlayer.CardsPiles.Hand.Count +
						" / Money: " + currentPlayer.MoneyCounter);
					Console.WriteLine("Choose what treasure card you want to play from hand or card you want to buy:");
					Console.Write("[0] - ");
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("End buy phase");
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write("[1] - ");
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("Autoplay all treasures");
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine("---------------------");
					Console.WriteLine("Your hand:");
					int counter = 2;
					foreach (Card card in currentPlayer.CardsPiles.Hand)
					{
						if (card is TreasureCard)
						{
							Console.Write("[" + (counter++) + "] - ");
						}
						CardsUtilities.printCardName(card);
					}
					Console.WriteLine("---------------------");
					Console.WriteLine("Game board piles:");
					List<string> cardsNames = globalCardsPiles.getCardsNames();
					foreach (string cardName in cardsNames)
					{
						if (globalCardsPiles.getCardsPile(cardName).CardTemplate.Cost <= currentPlayer.MoneyCounter
							&& globalCardsPiles.getCardsPile(cardName).size() > 0)
						{
							Console.Write("[" + (counter++) + "] - ");
						}
						Console.Write("\t");
						CardsUtilities.printCardName(globalCardsPiles.getCardsPile(cardName));
					}

					int playerChoice = Convert.ToInt32(Console.ReadLine());
					if (playerChoice == 0)
						break;
					if(playerChoice == 1)
					{
						currentPlayer.CardsPiles.playAllTreasureCards();
						clearConsoleButKeepPlayerTurn(currentPlayer);
						continue;
					}
					playerChoice--;
					if (playerChoice <= currentPlayer.CardsPiles.countTreasureCardsInHand())
					{
						currentPlayer.CardsPiles.playNthTreasureCard(playerChoice);
					}
					else
					{
						playerChoice -= currentPlayer.CardsPiles.countTreasureCardsInHand();
						currentPlayer.CardsPiles.buyNthCardPlayerCanBuy(playerChoice);
					}
					clearConsoleButKeepPlayerTurn(currentPlayer);
				}

				currentPlayer.finalizePlayerRound();
				currentPlayerIndex = (currentPlayerIndex + 1) % num_of_players;
				clearConsoleButKeepPlayerTurn(currentPlayer);
			}

			andTheWinnerIs();
		}

		public void clearConsoleButKeepPlayerTurn(Player currentPlayer)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("----------- " + currentPlayer.Name + "'s turn: ------------");
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		private bool isGameOver()
		{
			if (globalCardsPiles.getCardsPile("Province").isEmpty())
			{
				return true;
			}
			List<string> cardsNames = globalCardsPiles.getCardsNames();
			int emptyPilesCounter = 0;
			foreach (string cardName in cardsNames)
			{
				if (globalCardsPiles.getCardsPile(cardName).isEmpty())
				{
					emptyPilesCounter++;
				}
			}
			return (emptyPilesCounter >= MAX_EMPTY_PILES_THRESHOLD);
		}

		private void andTheWinnerIs()
		{
			for (int i = 0; i < num_of_players; i++)
			{
				Players[i].countPlayerVpsWhenGameEnds();
			}
			Array.Sort(Players);
			Array.Reverse(Players);
			Console.Clear();
			Console.WriteLine("Player:\tVPs:\tRounds played:");
			for (int i = 0; i < num_of_players; i++)
			{
				Console.WriteLine(Players[i].Name + "\t" + Players[i].PlayerVps + "\t" + Players[i].RoundsPlayed);
			}
		}

	}
}
