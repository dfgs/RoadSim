using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RoadSimLib
{
	public class Map : IMap
	{
		public IEnumerable<Cell> Cells
		{
			get
			{
				for(int Y=0;Y<height;Y++)
				{
					for(int X=0;X<width;X++)
					{
						yield return cells[X, Y];
					}
				}
			}
		}
		

		private Cell[,] cells;

		private int width;
		public int Width => width;
		
		private int height;
		public int Height => height;

		private Cell this[int X,int Y]
		{
			get
			{
				if ((X < 0) || (Y < 0) || (X >= width) || (Y >= height)) return null;
				return cells[X, Y];
			}
			set
			{
				if ((X < 0) || (Y < 0) || (X >= width) || (Y >= height)) return ;
				cells[X, Y] = value;
			}
		}


		public Map(int Width,int Height)
		{
			if (Width <= 0) throw new ArgumentOutOfRangeException(nameof(Width));
			if (Height <= 0) throw new ArgumentOutOfRangeException(nameof(Height));
			this.width = Width;this.height = Height;

			cells = new Cell[width, height];
		}

		public Cell GetCell(int X,int Y)
		{
			if ((X < 0) || (Y < 0) || (X >= width) || (Y >= height)) return null;
			return cells[X, Y];
		}
		


	}
}
