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




		


	}
}
