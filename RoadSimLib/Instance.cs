using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Instance : IInstance
	{
		public IMap Map
		{
			get;
			set;
		}

		public IDeck Deck
		{
			get;
			set;
		}
		public Instance()
		{

		}
		

	}
}
