using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestGUI.Views
{
	public class TileGrid : Panel
	{

		public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(TileGrid),new FrameworkPropertyMetadata(1,FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
		public int Columns
		{
			get { return (int)GetValue(ColumnsProperty); }
			set { SetValue(ColumnsProperty, value); }
		}


		public static readonly DependencyProperty RowsProperty = DependencyProperty.Register("Rows", typeof(int), typeof(TileGrid), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
		public int Rows
		{
			get { return (int)GetValue(RowsProperty); }
			set { SetValue(RowsProperty, value); }
		}

		public static readonly DependencyProperty TileWidthProperty = DependencyProperty.Register("TileWidth", typeof(int), typeof(TileGrid), new FrameworkPropertyMetadata(16, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
		public int TileWidth
		{
			get { return (int)GetValue(TileWidthProperty); }
			set { SetValue(TileWidthProperty, value); }
		}

		public static readonly DependencyProperty TileHeightProperty = DependencyProperty.Register("TileHeight", typeof(int), typeof(TileGrid), new FrameworkPropertyMetadata(16, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
		public int TileHeight
		{
			get { return (int)GetValue(TileHeightProperty); }
			set { SetValue(TileHeightProperty, value); }
		}



		

		public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached("X", typeof(int), typeof(TileGrid), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsParentArrange));
		public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached("Y", typeof(int), typeof(TileGrid), new FrameworkPropertyMetadata(0,  FrameworkPropertyMetadataOptions.AffectsParentArrange));



		

		



		public TileGrid()
		{
		}


		public static int GetX(DependencyObject obj)
		{
			return (int)obj.GetValue(XProperty);
		}

		public static void SetX(DependencyObject obj, int value)
		{
			obj.SetValue(XProperty, value);
		}
		public static int GetY(DependencyObject obj)
		{
			return (int)obj.GetValue(YProperty);
		}

		public static void SetY(DependencyObject obj, int value)
		{
			obj.SetValue(YProperty, value);
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			return new Size(TileWidth * Columns,TileHeight*Rows) ;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			foreach(UIElement children in Children)
			{
				children.Arrange(new Rect(GetX(children) * TileWidth, GetY(children) * TileHeight, TileWidth, TileHeight));
			}

			return base.ArrangeOverride(finalSize);
		}

	}
}
