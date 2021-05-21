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

		


		/*[TestMethod]
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
		}*/

	


	}
}
