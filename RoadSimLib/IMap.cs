using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface IMap
	{
		IEnumerable<Segment> Segments
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

		Cell GetCell(Vector Position);
		Segment GetSegment(Vector Position);
		Segment GetSegment(Vector Position, Directions Direction);
		Cell AddCell(Vector Position, Directions Direction);

	}
}
