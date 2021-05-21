using RoadSimLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestGUI.ViewModels
{
	public class TileViewModel:ViewModel<Tile>
	{

		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(TileViewModel));
		public string ImageSource
		{
			get { return (string)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}


		public TileViewModel():base()
		{

		}
		public TileViewModel(Tile Model) : base(Model)
		{

		}
		protected override void OnModelChanged(Tile OldValue, Tile NewValue)
		{
			base.OnModelChanged(OldValue, NewValue);
			if (Model == null) ImageSource = null;
			else ImageSource = $"Images/Tile{Model.Pattern}.png";
		}


	}
}
