using System;
using System.Collections.Generic;
using System.Text;

namespace Dominion
{
	public class CardPile
	{
		private Card cardTemplate;
		private List<Card> cards;

		public CardPile(Card card, int num)
		{
			cards = new List<Card>();
			cardTemplate = card;
			for (int i = 0; i < num; i++)
			{
				cards.Add(card.cloneCard());
			}
		}

		public Card CardTemplate { get { return cardTemplate; } }

		public bool isEmpty()
		{
			return (cards.Count == 0);
		}
		public int size()
		{
			return (cards.Count);
		}

		public Card drawCard()
		{
			if (isEmpty())
			{
				return null;
			}
			Card card = cards[cards.Count - 1];
			cards.RemoveAt(cards.Count - 1);
			return card;
		}
		public void addAnotherCard()
		{
			cards.Add(cardTemplate.cloneCard());
		}
	}
}
