using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{
	

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

		[TestMethod]
		public void ShouldGetCell()
		{
			Map map;

			map = new Map(10, 10);
			Assert.IsNotNull(map.GetCell(0, 0));
			Assert.IsNotNull(map.GetCell(9, 9));
		}
		[TestMethod]
		public void ShouldNotGetCell()
		{
			Map map;

			map = new Map(10, 10);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetCell(-1, 0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetCell(0, -1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetCell(10, 0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetCell(0, 10));
		}
		[TestMethod]
		public void ShouldGetTile()
		{
			Map map;

			map = new Map(10, 10);
			Assert.IsNotNull(map.GetTile(0, 0));
			Assert.IsNotNull(map.GetTile(9, 9));
		}
		[TestMethod]
		public void ShouldNotGetTile()
		{
			Map map;

			map = new Map(10, 10);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetTile(-1, 0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetTile(0, -1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetTile(10, 0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => map.GetTile(0, 10));
		}
	




	}
}
