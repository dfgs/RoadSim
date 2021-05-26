using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IMap
	{
		IEnumerable<ICell> Cells
		{
			get;
		}
		IEnumerable<ITile> Tiles
		{
			get;
		}
		int Width
		{
			get;
		}

		int Height
		{
			get;
		}
		ICell this[int X, int Y]
		{
			get;
		}

		ICell GetCell(int X, int Y);

		ITile GetTile(int X, int Y);

	}
}
