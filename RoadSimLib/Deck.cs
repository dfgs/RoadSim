using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Deck : IDeck
	{
		private List<Tile> tiles;
		public IEnumerable<ITile> Tiles => tiles;

		public int Count => tiles.Count;

		public int Capacity
		{
			get;
			set;
		}
		public Deck()
		{
			tiles = new List<Tile>();
			this.Capacity = 7;
		}
		public Deck(int Capacity)
		{
			if (Capacity <= 0)  throw new ArgumentOutOfRangeException(nameof(Capacity));
			tiles = new List<Tile>();
			this.Capacity = Capacity;
		}

	}
}
