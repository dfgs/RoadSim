using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IMap
	{
		IEnumerable<Cell> Cells
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

		Cell GetCell(int X,int Y);

	}
}
