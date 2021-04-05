using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{
	

	[TestClass]
	public class SegmentUnitTest
	{
		[TestMethod]
		public void ShouldGetPositionsWithUpDirection()
		{
			Segment segment;
			Vector[] positions;

			segment = new Segment() { Direction = Directions.Up, Position = new Vector(1, 5), Length = 5 };
			positions = segment.GetPositions().ToArray();
			Assert.AreEqual(5, positions.Length);
			Assert.IsTrue(positions.Contains(new Vector(1, 1)));
			Assert.IsTrue(positions.Contains(new Vector(1, 2)));
			Assert.IsTrue(positions.Contains(new Vector(1, 3)));
			Assert.IsTrue(positions.Contains(new Vector(1, 4)));
			Assert.IsTrue(positions.Contains(new Vector(1, 5)));
		}
		[TestMethod]
		public void ShouldGetPositionsWithDownDirection()
		{
			Segment segment;
			Vector[] positions;

			segment = new Segment() { Direction = Directions.Down, Position = new Vector(1, 1), Length = 5 };
			positions = segment.GetPositions().ToArray();
			Assert.AreEqual(5, positions.Length);
			Assert.IsTrue(positions.Contains(new Vector(1, 1)));
			Assert.IsTrue(positions.Contains(new Vector(1, 2)));
			Assert.IsTrue(positions.Contains(new Vector(1, 3)));
			Assert.IsTrue(positions.Contains(new Vector(1, 4)));
			Assert.IsTrue(positions.Contains(new Vector(1, 5)));
		}
		[TestMethod]
		public void ShouldGetPositionsWithLeftDirection()
		{
			Segment segment;
			Vector[] positions;

			segment = new Segment() { Direction = Directions.Left, Position = new Vector(5, 1), Length = 5 };
			positions = segment.GetPositions().ToArray();
			Assert.AreEqual(5, positions.Length);
			Assert.IsTrue(positions.Contains(new Vector(1, 1)));
			Assert.IsTrue(positions.Contains(new Vector(2, 1)));
			Assert.IsTrue(positions.Contains(new Vector(3, 1)));
			Assert.IsTrue(positions.Contains(new Vector(4, 1)));
			Assert.IsTrue(positions.Contains(new Vector(5, 1)));
		}
		[TestMethod]
		public void ShouldGetPositionsWithRightDirection()
		{
			Segment segment;
			Vector[] positions;

			segment = new Segment() { Direction = Directions.Right, Position = new Vector(1, 1), Length = 5 };
			positions = segment.GetPositions().ToArray();
			Assert.AreEqual(5, positions.Length);
			Assert.IsTrue(positions.Contains(new Vector(1, 1)));
			Assert.IsTrue(positions.Contains(new Vector(2, 1)));
			Assert.IsTrue(positions.Contains(new Vector(3, 1)));
			Assert.IsTrue(positions.Contains(new Vector(4, 1)));
			Assert.IsTrue(positions.Contains(new Vector(5, 1)));
		}

	}
}
