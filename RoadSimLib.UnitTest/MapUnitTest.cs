using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{
	/*
	←
	↑
	→
	↓
	*/

	[TestClass]
	public class MapUnitTest
	{
		[TestMethod]
		public void ShouldCheckConstructorParameters()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Map(0, 10));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Map(-1, 10));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Map(10, 0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Map(10, -1));
		}

		#region single cell
		[TestMethod]
		public void ShouldAddSegmentToEmptyMap()
		{
			IMap map;
			Cell cell;

			// -----
			// -----
			// -↑---
			// -----
			// -----


			map = new Map(5,5);
			cell=map.AddCell(new Vector(1, 2), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 2), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldNotAddCellIfOccupied()
		{
			IMap map;
			Cell cell;

			// -----
			// -----
			// -↑---
			// -----
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(1, 2), Directions.Up);
			Assert.ThrowsException<InvalidOperationException>(() => map.AddCell(new Vector(1, 2), Directions.Up));
		}
		#endregion

		#region extend existing segment
		[TestMethod]
		public void ShouldExtendExistingSegmentWithUpDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -↑---
			// -↑---
			// -↑---
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(1, 2), Directions.Up);

			cell = map.AddCell(new Vector(1, 1), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 2), cell.Segment.Position);
			Assert.AreEqual(2, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 3), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 3), cell.Segment.Position);
			Assert.AreEqual(3, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldExtendExistingSegmentWithDownDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -↓---
			// -↓---
			// -↓---
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(1, 2), Directions.Down);

			cell = map.AddCell(new Vector(1, 1), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(2, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 3), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(3, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());
		}


		[TestMethod]
		public void ShouldExtendExistingSegmentWithRightDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -→→→-
			// -----
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(2, 1), Directions.Right);

			cell = map.AddCell(new Vector(1, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(2, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			cell = map.AddCell(new Vector(3, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(3, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldExtendExistingSegmentWithLeftDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -←←←-
			// -----
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(2, 1), Directions.Left);

			cell = map.AddCell(new Vector(1, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(2, 1), cell.Segment.Position);
			Assert.AreEqual(2, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			cell = map.AddCell(new Vector(3, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(3, 1), cell.Segment.Position);
			Assert.AreEqual(3, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());
		}
		#endregion

		#region doesn't extend existing segment if direction is different
		[TestMethod]
		public void ShouldNotExtendExistingSegmentWithUpDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -↓---
			// -↑---
			// -↓---
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(1, 2), Directions.Up);

			cell = map.AddCell(new Vector(1, 1), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 3), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 3), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldNotExtendExistingSegmentWithDownDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -↑---
			// -↓---
			// -↑---
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(1, 2), Directions.Down);

			cell = map.AddCell(new Vector(1, 1), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 3), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 3), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());
		}


		[TestMethod]
		public void ShouldNotExtendExistingSegmentWithRightDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -←→←-
			// -----
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(2, 1), Directions.Right);

			cell = map.AddCell(new Vector(1, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(3, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(3, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldNotExtendExistingSegmentWithLeftDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// -→←→-
			// -----
			// -----


			map = new Map(5, 5);
			cell = map.AddCell(new Vector(2, 1), Directions.Left);

			cell = map.AddCell(new Vector(1, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(3, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(3, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());
		}
		#endregion

		#region merge existing segments
		[TestMethod]
		public void ShouldMergeExistingSegmentWithUpDirection()
		{
			IMap map;
			Cell cell;

			// -↑---
			// -↑---
			// -↑---
			// -↑---
			// -↑---


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(1, 0), Directions.Up);
			cell = map.AddCell(new Vector(1, 1), Directions.Up);
			cell = map.AddCell(new Vector(1, 3), Directions.Up);
			cell = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 2), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 4), cell.Segment.Position);
			Assert.AreEqual(5, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			foreach(Cell c in cell.Segment.GetPositions().Select(position=>map.GetCell(position)))
			{
				Assert.AreEqual(c.Segment, cell.Segment);
			}
		}
		[TestMethod]
		public void ShouldMergeExistingSegmentWithDownDirection()
		{
			IMap map;
			Cell cell;

			// -↓---
			// -↓---
			// -↓---
			// -↓---
			// -↓---


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(1, 0), Directions.Down);
			cell = map.AddCell(new Vector(1, 1), Directions.Down);
			cell = map.AddCell(new Vector(1, 3), Directions.Down);
			cell = map.AddCell(new Vector(1, 4), Directions.Down);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 2), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 0), cell.Segment.Position);
			Assert.AreEqual(5, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			foreach (Cell c in cell.Segment.GetPositions().Select(position => map.GetCell(position)))
			{
				Assert.AreEqual(c.Segment, cell.Segment);
			}
		}
		[TestMethod]
		public void ShouldMergeExistingSegmentWithRightDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// →→→→→
			// -----
			// -----
			// -----


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(0, 1), Directions.Right);
			cell = map.AddCell(new Vector(1, 1), Directions.Right);
			cell = map.AddCell(new Vector(3, 1), Directions.Right);
			cell = map.AddCell(new Vector(4, 1), Directions.Right);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(2, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(0, 1), cell.Segment.Position);
			Assert.AreEqual(5, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			foreach (Cell c in cell.Segment.GetPositions().Select(position => map.GetCell(position)))
			{
				Assert.AreEqual(c.Segment, cell.Segment);
			}
		}
		[TestMethod]
		public void ShouldMergeExistingSegmentWithLeftDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// ←←←←←
			// -----
			// -----
			// -----


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(0, 1), Directions.Left);
			cell = map.AddCell(new Vector(1, 1), Directions.Left);
			cell = map.AddCell(new Vector(3, 1), Directions.Left);
			cell = map.AddCell(new Vector(4, 1), Directions.Left);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(2, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(4, 1), cell.Segment.Position);
			Assert.AreEqual(5, cell.Segment.Length);
			Assert.AreEqual(1, map.Segments.Count());

			foreach (Cell c in cell.Segment.GetPositions().Select(position => map.GetCell(position)))
			{
				Assert.AreEqual(c.Segment, cell.Segment);
			}
		}
		#endregion

		#region doesn't merge existing segments if direction is different
		[TestMethod]
		public void ShouldNotMergeExistingSegmentWithUpDirection()
		{
			IMap map;
			Cell cell;

			// -↑---
			// -↑---
			// -↓---
			// -↑---
			// -↑---


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(1, 0), Directions.Up);
			cell = map.AddCell(new Vector(1, 1), Directions.Up);
			cell = map.AddCell(new Vector(1, 3), Directions.Up);
			cell = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 2), Directions.Down);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Down, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 2), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());

		}
		[TestMethod]
		public void ShouldNotMergeExistingSegmentWithDownDirection()
		{
			IMap map;
			Cell cell;

			// -↓---
			// -↓---
			// -↑---
			// -↓---
			// -↓---


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(1, 0), Directions.Down);
			cell = map.AddCell(new Vector(1, 1), Directions.Down);
			cell = map.AddCell(new Vector(1, 3), Directions.Down);
			cell = map.AddCell(new Vector(1, 4), Directions.Down);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(1, 2), Directions.Up);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Up, cell.Segment.Direction);
			Assert.AreEqual(new Vector(1, 2), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());

		}
		[TestMethod]
		public void ShouldNotMergeExistingSegmentWithRightDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// →→←→→
			// -----
			// -----
			// -----


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(0, 1), Directions.Right);
			cell = map.AddCell(new Vector(1, 1), Directions.Right);
			cell = map.AddCell(new Vector(3, 1), Directions.Right);
			cell = map.AddCell(new Vector(4, 1), Directions.Right);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(2, 1), Directions.Left);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Left, cell.Segment.Direction);
			Assert.AreEqual(new Vector(2, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());

			
		}
		[TestMethod]
		public void ShouldNotMergeExistingSegmentWithLeftDirection()
		{
			IMap map;
			Cell cell;

			// -----
			// ←←→←←
			// -----
			// -----
			// -----


			map = new Map(5, 5);

			cell = map.AddCell(new Vector(0, 1), Directions.Left);
			cell = map.AddCell(new Vector(1, 1), Directions.Left);
			cell = map.AddCell(new Vector(3, 1), Directions.Left);
			cell = map.AddCell(new Vector(4, 1), Directions.Left);

			Assert.AreEqual(2, map.Segments.Count());

			cell = map.AddCell(new Vector(2, 1), Directions.Right);
			Assert.IsNotNull(cell);
			Assert.IsNotNull(cell.Segment);
			Assert.AreEqual(Directions.Right, cell.Segment.Direction);
			Assert.AreEqual(new Vector(2, 1), cell.Segment.Position);
			Assert.AreEqual(1, cell.Segment.Length);
			Assert.AreEqual(3, map.Segments.Count());

			
		}
		#endregion

		[TestMethod]
		public void ShouldEnumerateSegments()
		{
			IMap map;
			Cell cell1, cell2, cell3;

			// -↑---
			// -----
			// -↑---
			// -----
			// -↑---


			map = new Map(5, 5);
			cell1 = map.AddCell(new Vector(1, 0), Directions.Up);
			cell2 = map.AddCell(new Vector(1, 2), Directions.Up);
			cell3 = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(3, map.Segments.Count());
		}

		[TestMethod]
		public void ShouldGetCell()
		{
			IMap map;
			Cell cell1, cell2, cell3;

			// -↑---
			// -----
			// -↑---
			// -----
			// -↑---


			map = new Map(5, 5);
			cell1 = map.AddCell(new Vector(1, 0), Directions.Up);
			cell2 = map.AddCell(new Vector(1, 2), Directions.Up);
			cell3 = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(cell1, map.GetCell(new Vector(1, 0)));
			Assert.AreEqual(cell2, map.GetCell(new Vector(1, 2)));
			Assert.AreEqual(cell3, map.GetCell(new Vector(1, 4)));
			Assert.IsNull(map.GetCell(new Vector(0, 0)));
			Assert.IsNull(map.GetCell(new Vector(-1, -1)));
			Assert.IsNull(map.GetCell(new Vector(20, 20)));
		}

		[TestMethod]
		public void ShouldGetSegment()
		{
			IMap map;
			Cell cell1, cell2, cell3;

			// -↑---
			// -----
			// -↑---
			// -----
			// -↑---


			map = new Map(5, 5);
			cell1 = map.AddCell(new Vector(1, 0), Directions.Up);
			cell2 = map.AddCell(new Vector(1, 2), Directions.Up);
			cell3 = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(cell1.Segment, map.GetSegment(new Vector(1, 0)));
			Assert.AreEqual(cell2.Segment, map.GetSegment(new Vector(1, 2)));
			Assert.AreEqual(cell3.Segment, map.GetSegment(new Vector(1, 4)));
			Assert.IsNull(map.GetSegment(new Vector(0, 0)));
			Assert.IsNull(map.GetSegment(new Vector(-1, -1)));
			Assert.IsNull(map.GetSegment(new Vector(20, 20)));
		}

		[TestMethod]
		public void ShouldGetSegmentWithCorrectDirection()
		{
			IMap map;
			Cell cell1, cell2, cell3;

			// -↑---
			// -----
			// -↑---
			// -----
			// -↑---


			map = new Map(5, 5);
			cell1 = map.AddCell(new Vector(1, 0), Directions.Up);
			cell2 = map.AddCell(new Vector(1, 2), Directions.Up);
			cell3 = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.AreEqual(cell1.Segment, map.GetSegment(new Vector(1, 0),Directions.Up));
			Assert.AreEqual(cell2.Segment, map.GetSegment(new Vector(1, 2), Directions.Up));
			Assert.AreEqual(cell3.Segment, map.GetSegment(new Vector(1, 4), Directions.Up));
			Assert.IsNull(map.GetSegment(new Vector(0, 0), Directions.Up));
			Assert.IsNull(map.GetSegment(new Vector(-1, -1), Directions.Up));
			Assert.IsNull(map.GetSegment(new Vector(20, 20), Directions.Up));
		}
		[TestMethod]
		public void ShouldGetSegmentWithWrongDirection()
		{
			IMap map;
			Cell cell1, cell2, cell3;

			// -↑---
			// -----
			// -↑---
			// -----
			// -↑---


			map = new Map(5, 5);
			cell1 = map.AddCell(new Vector(1, 0), Directions.Up);
			cell2 = map.AddCell(new Vector(1, 2), Directions.Up);
			cell3 = map.AddCell(new Vector(1, 4), Directions.Up);

			Assert.IsNull(map.GetSegment(new Vector(1, 0), Directions.Down));
			Assert.IsNull(map.GetSegment(new Vector(1, 4), Directions.Down));
			Assert.IsNull(map.GetSegment(new Vector(0, 0), Directions.Down));
			Assert.IsNull(map.GetSegment(new Vector(-1, -1), Directions.Down));
			Assert.IsNull(map.GetSegment(new Vector(20, 20), Directions.Down));
		}


	}
}
