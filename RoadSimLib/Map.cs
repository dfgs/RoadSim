using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RoadSimLib
{
	public class Map : IMap
	{
		public IEnumerable<ICell> Cells
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

		public IEnumerable<ITile> Tiles
		{
			get
			{
				for (int Y = 0; Y < height; Y++)
				{
					for (int X = 0; X < width; X++)
					{
						yield return tiles[X, Y];
					}
				}
			}
		}

		private ICell[,] cells;
		private ITile[,] tiles;

		private int width;
		public int Width => width;
		
		private int height;
		public int Height => height;

		public ICell this[int X,int Y]
		{
			get
			{
				if ((X < 0) || (X >= width)) throw new ArgumentOutOfRangeException(nameof(X));
				if ((Y < 0) || (Y >= height)) throw new ArgumentOutOfRangeException(nameof(Y));
				return cells[X, Y];
			}
			/*set
			{
				if ((X < 0) || (Y < 0) || (X >= width) || (Y >= height)) return ;
				cells[X, Y] = value;
			}*/
		}


		public Map(int Width,int Height)
		{
			if (Width <= 0) throw new ArgumentOutOfRangeException(nameof(Width));
			if (Height <= 0) throw new ArgumentOutOfRangeException(nameof(Height));
			this.width = Width;this.height = Height;

			cells = new Cell[width, height];
			tiles = new Tile[width, height];

			for (int Y = 0; Y < height; Y++)
			{
				for (int X = 0; X < width; X++)
				{
					cells[X, Y] = new Cell(X, Y);
					tiles[X, Y] = new Tile(X, Y,0);
				}
			}
		}

		public ICell GetCell(int X,int Y)
		{
			if ((X < 0) || (X >= width)) throw new ArgumentOutOfRangeException(nameof(X));
			if ((Y < 0) || (Y >= height)) throw new ArgumentOutOfRangeException(nameof(Y));
			return cells[X, Y];
		}

		public ITile GetTile(int X, int Y)
		{
			if ((X < 0) || (X >= width)) throw new ArgumentOutOfRangeException(nameof(X));
			if ((Y < 0) || (Y >= height)) throw new ArgumentOutOfRangeException(nameof(Y));
			return tiles[X, Y];
		}

	}
}
