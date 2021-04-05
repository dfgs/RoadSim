using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public struct Vector
	{
		public int X
		{
			get;
			private set;
		}
		public int Y
		{
			get;
			private set;
		}

		public Vector(int X,int Y)
		{
			this.X = X;this.Y = Y;
		}

		public static Vector DirectionToVector(Directions Direction)
		{
			switch (Direction)
			{
				case Directions.Down: return new Vector(0, 1);
				case Directions.Up: return new Vector(0, -1);
				case Directions.Left: return new Vector(-1, 0);
				case Directions.Right: return new Vector(1, 0);
				default: throw new InvalidOperationException($"Invalid direction: {Direction}");
			}
		}

		public override string ToString()
		{
			return $"{X},{Y}";
		}

		public static Vector operator +(Vector A, Vector B)
		{
			return new Vector(A.X + B.X, A.Y + B.Y);
		}
		public static Vector operator -(Vector A, Vector B)
		{
			return new Vector(A.X - B.X, A.Y - B.Y);
		}
		public static Vector operator *(int B, Vector A)
		{
			return new Vector(A.X *B, A.Y *B);
		}
	}
}
