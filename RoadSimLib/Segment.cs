using System;
using System.Collections.Generic;
using System.Linq;
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

		private List<SegmentItem> items;
		public IEnumerable<SegmentItem> Items => items;
		

		public Segment()
		{
			items = new List<SegmentItem>();
		}

		public IEnumerable<Vector> GetPositions()
		{
			Vector delta;

			delta = Vector.DirectionToVector(Direction);
			for (int t = 0; t < Length; t++) yield return Position + t * delta;
		}

		public float GetDistanceFromLastItem()
		{
			if (items.Count == 0) return Length;
			return (Length-items[items.Count - 1].Distance);
		}

	}
}
