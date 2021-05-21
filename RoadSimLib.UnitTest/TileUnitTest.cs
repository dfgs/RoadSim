using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{
	
	[TestClass]
	public class TileUnitTest
	{
		[TestMethod]
		public void ShouldCheckConstructorParameters()
		{
			Tile tile;

			tile = new Tile();
			Assert.AreEqual(1, tile.Pattern);
			tile = new Tile(3);
			Assert.AreEqual(3, tile.Pattern);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Tile(-1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Tile(0));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Tile(16));
		}




		[TestMethod]
		public void ShouldRotateUsingStaticMethod()
		{

			Assert.AreEqual(2, Tile.Rotate(1));
			Assert.AreEqual(4, Tile.Rotate(2));
			Assert.AreEqual(8, Tile.Rotate(4));
			Assert.AreEqual(1, Tile.Rotate(8));


			Assert.AreEqual(6, Tile.Rotate(3));
			Assert.AreEqual(12, Tile.Rotate(6));
			Assert.AreEqual(9, Tile.Rotate(12));
			Assert.AreEqual(3, Tile.Rotate(9));

			Assert.AreEqual(14, Tile.Rotate(7));
			Assert.AreEqual(13, Tile.Rotate(14));
			Assert.AreEqual(11, Tile.Rotate(13));
			Assert.AreEqual(7, Tile.Rotate(11));

			Assert.AreEqual(15, Tile.Rotate(15));
		}

		[TestMethod]
		public void ShouldRotate()
		{
			Tile tile;

			tile = new Tile();
			tile.Pattern = 1;

			Assert.AreEqual(1, tile.Pattern);
			tile.Rotate();
			Assert.AreEqual(2, tile.Pattern);
			tile.Rotate();
			Assert.AreEqual(4, tile.Pattern);
			tile.Rotate();
			Assert.AreEqual(8, tile.Pattern);
			
		}


	}
}
