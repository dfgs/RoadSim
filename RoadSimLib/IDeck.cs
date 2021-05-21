using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IDeck
	{
		IEnumerable<ITile> Tiles
		{
			get;
		}

		int Count
		{
			get;
		}

		int Capacity
		{
			get;
		}

	}
}
