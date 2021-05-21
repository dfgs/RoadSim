using RoadSimLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestGUI.ViewModels
{
	public class DeckViewModel : ViewModel<Deck>
	{

		public static readonly DependencyProperty TilesProperty = DependencyProperty.Register("Tiles", typeof(ObservableCollection<TileViewModel>), typeof(DeckViewModel));
		public ObservableCollection<TileViewModel> Tiles
		{
			get { return (ObservableCollection<TileViewModel>)GetValue(TilesProperty); }
			set { SetValue(TilesProperty, value); }
		}


		public DeckViewModel()
		{
			
		}

		public DeckViewModel(Deck Model) : base(Model)
		{
		}

		protected override void OnModelChanged(Deck OldValue, Deck NewValue)
		{
			base.OnModelChanged(OldValue, NewValue);

			if (Model == null) Tiles = null;
			else
			{
				Tiles = new ObservableCollection<TileViewModel>();
				foreach(Tile tile in Model.Tiles)
				{
					Tiles.Add(new TileViewModel(tile));
				}
			}
		}

	}
}
