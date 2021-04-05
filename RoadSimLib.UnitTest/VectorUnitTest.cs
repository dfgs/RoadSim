using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace RoadSimLib.UnitTest
{
	

	[TestClass]
	public class VectorUnitTest
	{
		[TestMethod]
		public void ShouldAdd()
		{
			Vector result;

			result = new Vector(1, 2) + new Vector(3, 4);
			Assert.AreEqual(new Vector(4, 6), result);
		}
		[TestMethod]
		public void ShouldSubstract()
		{
			Vector result;

			result = new Vector(3, 4) - new Vector(1, 2);
			Assert.AreEqual(new Vector(2, 2), result);
		}
		[TestMethod]
		public void ShouldMultiply()
		{
			Vector result;

			result = 2*new Vector(3, 4);
			Assert.AreEqual(new Vector(6, 8), result);
		}
		[TestMethod]
		public void ShouldConvertFromDirection()
		{
			Assert.AreEqual(new Vector(0, -1), Vector.DirectionToVector(Directions.Up));
			Assert.AreEqual(new Vector(0, 1), Vector.DirectionToVector(Directions.Down));
			Assert.AreEqual(new Vector(-1, 0), Vector.DirectionToVector(Directions.Left));
			Assert.AreEqual(new Vector(1, 0), Vector.DirectionToVector(Directions.Right));
		}


	}
}
