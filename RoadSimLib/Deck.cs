using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Deck : IDeck
	{
		private List<ICard> cards;
		public IEnumerable<ICard> Cards => cards;

		public int Count => cards.Count;

		public int Capacity
		{
			get;
			set;
		}
		public Deck()
		{
			cards = new List<ICard>();
			this.Capacity = 7;
		}
		public Deck(int Capacity)
		{
			if (Capacity <= 0)  throw new ArgumentOutOfRangeException(nameof(Capacity));
			cards = new List<ICard>();
			this.Capacity = Capacity;
		}

		public void Add(ICard Card)
		{
			if (Card == null) throw new ArgumentNullException(nameof(Card));
			if (Count == Capacity) throw new InvalidOperationException("Deck reached maximum capacity");
			cards.Add(Card);
		}

	}
}
