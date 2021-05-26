using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IInstance
	{
		IMap Map
		{
			get;
		}
		IDeck Deck
		{
			get;
		}
	}
}
