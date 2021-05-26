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
			Card tile;

			tile = new Card();
			Assert.AreEqual(1, tile.Pattern);
			tile = new Card(3);
			Assert.AreEqual(3, tile.Pattern);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(-1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(16));
		}




		[TestMethod]
		public void ShouldRotateUsingStaticMethod()
		{

			Assert.AreEqual(0, Card.Rotate(0));

			Assert.AreEqual(2, Card.Rotate(1));
			Assert.AreEqual(4, Card.Rotate(2));
			Assert.AreEqual(8, Card.Rotate(4));
			Assert.AreEqual(1, Card.Rotate(8));


			Assert.AreEqual(6, Card.Rotate(3));
			Assert.AreEqual(12, Card.Rotate(6));
			Assert.AreEqual(9, Card.Rotate(12));
			Assert.AreEqual(3, Card.Rotate(9));

			Assert.AreEqual(14, Card.Rotate(7));
			Assert.AreEqual(13, Card.Rotate(14));
			Assert.AreEqual(11, Card.Rotate(13));
			Assert.AreEqual(7, Card.Rotate(11));

			Assert.AreEqual(15, Card.Rotate(15));
		}

		[TestMethod]
		public void ShouldRotate()
		{
			Card tile;

			tile = new Card();
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
