using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RoadSimLib
{
	public class Map : IMap
	{
		private List<Segment> segments;
		public IEnumerable<Segment> Segments => segments;

		private Cell[,] cells;

		private int width;
		public int Width => width;
		
		private int height;
		public int Height => height;

		private Cell this[Vector Position]
		{
			get => cells[Position.X, Position.Y];
			set => cells[Position.X, Position.Y]=value;
		}


		public Map(int Width,int Height)
		{
			if (Width <= 0) throw new ArgumentOutOfRangeException(nameof(Width));
			if (Height <= 0) throw new ArgumentOutOfRangeException(nameof(Height));
			this.width = Width;this.height = Height;

			cells = new Cell[width, height];
			segments = new List<Segment>();
		}

		public Cell GetCell(Vector Position)
		{
			if ((Position.X < 0) || (Position.Y < 0) || (Position.X >= width) || (Position.Y >= height)) return null;
			return cells[Position.X, Position.Y];
		}
		public Segment GetSegment(Vector Position)
		{
			if ((Position.X < 0) || (Position.Y < 0) || (Position.X >= width) || (Position.Y >= height)) return null;
			return cells[Position.X, Position.Y]?.Segment;
		}
		public Segment GetSegment(Vector Position, Directions Direction)
		{
			Cell cell;

			if ((Position.X < 0) || (Position.Y < 0) || (Position.X >= width) || (Position.Y >= height)) return null;
			cell = cells[Position.X, Position.Y];
			if ( cell== null) return null;
			if (cell.Segment.Direction != Direction) return null;
			return cell.Segment;
		}
		


		public Cell AddCell(Vector Position, Directions Direction)
		{
			Segment previousSegment,nextSegment,segment;
			Vector delta;

			if (cells[Position.X, Position.Y] != null) throw new InvalidOperationException("Cell already exists");

			delta = Vector.DirectionToVector(Direction);

			previousSegment = GetSegment(Position-delta,Direction);
			nextSegment = GetSegment(Position+delta, Direction);

			if ((previousSegment != null) && (nextSegment != null))
			{
				// fusion
				segments.Remove(previousSegment);
				segments.Remove(nextSegment);

				segment = new Segment() { Direction = Direction, Position = previousSegment.Position, Length = nextSegment.Length+previousSegment.Length+1 };
				segments.Add(segment);
				foreach (Cell cell in previousSegment.GetPositions().Union(nextSegment.GetPositions()).Select(position=>this[position]))
				{
					cell.Segment = segment;
				}
			}
			else if ((previousSegment == null) && (nextSegment == null))
			{
				// creation
				segment = new Segment() { Direction = Direction, Position=Position,Length=1 };
				segments.Add(segment);
			}
			else if (previousSegment!=null)
			{
				// extend previous
				segment= previousSegment;
				segment.Length += 1;
			}
			else
			{
				// extend next
				segment = nextSegment;
				segment.Position = Position;
				segment.Length += 1;
			}


			this[Position] = new Cell() { Segment = segment };

			return this[Position];
		}


	}
}
