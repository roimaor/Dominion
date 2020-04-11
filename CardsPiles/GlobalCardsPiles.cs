using System;
using System.Collections.Generic;
using System.Text;
using Dominion.Cards;
using Dominion.Cards.Action_cards;
using Dominion.Cards.Treasure_cards;
using Dominion.Cards.Victory_cards;

namespace Dominion
{
	public class GlobalCardsPiles
	{
		private const int NUM_OF_RANDOM_CARDS = 10;

		private DominionGame gameBoard;

		private Dictionary<string, CardPile> CardsPiles;

		private List<Card> trashPile;

		public GlobalCardsPiles(DominionGame gameBoard)
		{
			this.gameBoard = gameBoard;
			CardsPiles = new Dictionary<string, CardPile>();
			trashPile = new List<Card>();
			initBasicCardsPiles();
			initRandomCardsPiles();
		}

		public List<Card> TrashPile { get { return trashPile; } }

		public void trashCard(Card card)
		{
			trashPile.Add(card);
		}

		public CardPile getCardsPile(string cardName)
		{
			return CardsPiles[cardName];
		}

		public List<string> getCardsNames()
		{
			List<string> names = new List<string>();
			foreach (string name in CardsPiles.Keys)
			{
				names.Add(name);
			}
			names.Sort(globalCardsComparison);
			return names;
		}

		public int globalCardsComparison(string cardName1, string cardName2)
		{
			return CardsUtilities.comparison(getCardsPile(cardName1).CardTemplate, getCardsPile(cardName2).CardTemplate);
		}

		private void initBasicCardsPiles()
		{
			// Victory cards
			CardsPiles.Add("Curse", new CardPile(new CurseCard(),10));
			CardsPiles.Add("Estate", new CardPile(new EstateCard(), 14));
			CardsPiles.Add("Duchy", new CardPile(new DuchyCard(), 8));
			CardsPiles.Add("Province", new CardPile(new ProvinceCard(), 8));

			// Treasure cards
			CardsPiles.Add("Copper", new CardPile(new CopperCard(), 60));
			CardsPiles.Add("Silver", new CardPile(new SilverCard(), 40));
			CardsPiles.Add("Gold", new CardPile(new GoldCard(), 30));
		}
		private void initRandomCardsPiles()
		{
			List<Card> randomCards = new List<Card>();
			// All options of random cards
			//randomCards.Add(new ActionCard("Artisan",        6, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Bandit",         5, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Bureaucart",     4, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Cellar",         2, null, null, 1, 0, 0, 0));
			//randomCards.Add(new ActionCard("Chapel",         2, null, null, 0, 0, 0, 0));
			randomCards.Add(new CouncilRoomCard());
			randomCards.Add(new FestivalCard());
			randomCards.Add(new GardensCard());
			//randomCards.Add(new ActionCard("Harbinger",      3, null, null, 1, 1, 0, 0));
			randomCards.Add(new LaboratoryCard());
			//randomCards.Add(new ActionCard("Library",        5, null, null, 0, 0, 0, 0));
			randomCards.Add(new MarketCard());
			//randomCards.Add(new ActionCard("Merchant",       3, null, null, 1, 1, 0, 0));
			//randomCards.Add(new ActionCard("Militia",        4, null, null, 0, 0, 0, 2));
			//randomCards.Add(new ActionCard("Mine",           5, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Moat",           2, null, null, 0, 2, 0, 0));
			//randomCards.Add(new ActionCard("Moneylender",    4, null, null, 0, 0, 0, 0));
			randomCards.Add(new PoacherCard());
			//randomCards.Add(new ActionCard("Remodel",        4, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Sentry",         5, null, null, 1, 1, 0, 0));
			randomCards.Add(new SmithyCard());
			//randomCards.Add(new ActionCard("Throne room",    4, null, null, 0, 0, 0, 0));
			//randomCards.Add(new ActionCard("Vassal",         3, null, null, 0, 0, 0, 2));
			randomCards.Add(new VillageCard());
			randomCards.Add(new WitchCard());
			randomCards.Add(new WorkshopCard());

			Random rnd = new Random();
			for (int i = 0; i < NUM_OF_RANDOM_CARDS; i++)
			{
				int index = rnd.Next(0, randomCards.Count);
				CardsPiles.Add(randomCards[index].Name, new CardPile(randomCards[index], 10));
				randomCards.RemoveAt(index);
			}

		}
	}
}
