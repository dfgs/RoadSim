using RoadSimLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLib;

namespace TestGUI.ViewModels
{
	public class MapViewModel : ViewModel<IMap>
	{

		public static readonly DependencyProperty TilesProperty = DependencyProperty.Register("Tiles", typeof(TilesViewModel), typeof(MapViewModel));
		public TilesViewModel Tiles
		{
			get { return (TilesViewModel)GetValue(TilesProperty); }
			set { SetValue(TilesProperty, value); }
		}


		public MapViewModel()
		{
			
		}

		public MapViewModel(IMap Model) : base(Model)
		{
		}

		protected override void OnModelChanged(IMap OldValue, IMap NewValue)
		{
			base.OnModelChanged(OldValue, NewValue);

			if (Model == null) Tiles = null;
			else
			{
				Tiles = new TilesViewModel();
				foreach(Tile tile in Model.Tiles)
				{
					Tiles.Add(new TileViewModel(tile));
				}
			}
		}

	}
}
