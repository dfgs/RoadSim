using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Cell : ICell
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
		public Cell()
		{

		}

		public Cell(int X,int Y)
		{
			this.X = X;this.Y = Y;
		}


	}
}
