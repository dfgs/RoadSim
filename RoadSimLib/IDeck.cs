using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IDeck
	{
		IEnumerable<ICard> Cards
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

		void Add(ICard Card);

	}
}
