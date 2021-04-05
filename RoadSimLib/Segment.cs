using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public class Segment
	{
		public Directions Direction
		{
			get;
			set;
		}
		public Vector Position
		{
			get;
			set;
		}


		public int Length
		{
			get;
			set;
		}

		public IEnumerable<Vector> GetPositions()
		{
			Vector delta;

			delta = Vector.DirectionToVector(Direction);
			for (int t = 0; t < Length; t++) yield return Position + t * delta;
		}


	}
}
