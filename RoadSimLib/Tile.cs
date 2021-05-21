using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Tile:ITile
	{
		public int Pattern
		{
			get;
			set;
		}

		public Tile()
		{
			Pattern = 1;
		}

		public Tile(int Pattern)
		{
			if ((Pattern <= 0) || (Pattern > 15)) throw new ArgumentOutOfRangeException(nameof(Pattern));
			this.Pattern=Pattern;
		}

		public static int Rotate(int Pattern)
		{
			if (Pattern == 15) return 15;
			return (Pattern<<1)%15;
		}

		public void Rotate()
		{
			this.Pattern = Rotate(Pattern);
		}

	}
}
