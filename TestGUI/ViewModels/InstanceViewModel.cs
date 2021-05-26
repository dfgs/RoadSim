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
	public class InstanceViewModel : ViewModel<Instance>
	{


		public static readonly DependencyProperty DeckProperty = DependencyProperty.Register("Deck", typeof(DeckViewModel), typeof(InstanceViewModel));
		public DeckViewModel Deck
		{
			get { return (DeckViewModel)GetValue(DeckProperty); }
			set { SetValue(DeckProperty, value); }
		}


		public static readonly DependencyProperty MapProperty = DependencyProperty.Register("Map", typeof(MapViewModel), typeof(InstanceViewModel));
		public MapViewModel Map
		{
			get { return (MapViewModel)GetValue(MapProperty); }
			set { SetValue(MapProperty, value); }
		}



		public InstanceViewModel()
		{
			
		}

		public InstanceViewModel(Instance Model) : base(Model)
		{
		}

		protected override void OnModelChanged(Instance OldValue, Instance NewValue)
		{
			base.OnModelChanged(OldValue, NewValue);

			if (Model == null)
			{
				Deck = null;Map = null;
				return;
			}

			Deck = new DeckViewModel(Model.Deck);
			Map = new MapViewModel(Model.Map);
			
		}

	}
}
