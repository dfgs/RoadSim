using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Deck : IDeck
	{
		private List<ITile> tiles;
		public IEnumerable<ITile> Tiles => tiles;

		public int Count => tiles.Count;

		public int Capacity
		{
			get;
			set;
		}
		public Deck()
		{
			tiles = new List<ITile>();
			this.Capacity = 7;
		}
		public Deck(int Capacity)
		{
			if (Capacity <= 0)  throw new ArgumentOutOfRangeException(nameof(Capacity));
			tiles = new List<ITile>();
			this.Capacity = Capacity;
		}

		public void Add(ITile Tile)
		{
			if (Tile == null) throw new ArgumentNullException(nameof(Tile));
			if (Count == Capacity) throw new InvalidOperationException("Deck reached maximum capacity");
			tiles.Add(Tile);
		}

	}
}
