using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{

	[TestClass]
	public class DeckUnitTest
	{
		[TestMethod]
		public void ShouldCheckConstructorParameters()
		{
			Deck deck;

			deck = new Deck();
			Assert.AreEqual(7, deck.Capacity);
			deck = new Deck(3);
			Assert.AreEqual(3, deck.Capacity);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Deck(-1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Deck(0));
		}


		[TestMethod]
		public void ShouldAddTile()
		{
			Deck deck;

			deck = new Deck();
			Assert.AreEqual(0, deck.Count);
			deck.Add(new Tile());
			Assert.AreEqual(1, deck.Count);
		}

		[TestMethod]
		public void ShouldNotAddNullTile()
		{
			Deck deck;

			deck = new Deck();
			Assert.AreEqual(0, deck.Count);
			Assert.ThrowsException<ArgumentNullException>(()=> deck.Add(null));
		}
		[TestMethod]
		public void ShouldNotAddTileOverCapacity()
		{
			Deck deck;

			deck = new Deck(1);
			Assert.AreEqual(0, deck.Count);
			deck.Add(new Tile());
			Assert.AreEqual(1, deck.Count);
			Assert.ThrowsException<InvalidOperationException>(() => deck.Add(new Tile()));
		}


	}
}