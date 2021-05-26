using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Tile : ITile
	{
		public int X
		{
			get;
			set;
		}

		public int Y
		{
			get;
			set;
		}
		public int Pattern
		{
			get;
			set;
		}
		public Tile()
		{

		}

		public Tile(int X,int Y,int Pattern)
		{
			this.X = X;this.Y = Y;this.Pattern = Pattern;
		}


	}
}
