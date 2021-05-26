﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RoadSimLib
{
	public interface ITile
	{
		int X
		{
			get;
		}
		int Y
		{
			get;
		}
		int Pattern
		{
			get;
		}
	}
}
