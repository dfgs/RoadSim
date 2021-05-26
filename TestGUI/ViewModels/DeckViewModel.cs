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
	public class DeckViewModel : ViewModel<IDeck>
	{

		public static readonly DependencyProperty CardsProperty = DependencyProperty.Register("Cards", typeof(ViewModelCollection<CardViewModel>), typeof(DeckViewModel));
		public ViewModelCollection<CardViewModel> Cards
		{
			get { return (ViewModelCollection<CardViewModel>)GetValue(CardsProperty); }
			set { SetValue(CardsProperty, value); }
		}


		public DeckViewModel()
		{
			
		}

		public DeckViewModel(IDeck Model) : base(Model)
		{
		}

		protected override void OnModelChanged(IDeck OldValue, IDeck NewValue)
		{
			base.OnModelChanged(OldValue, NewValue);

			if (Model == null) Cards = null;
			else
			{
				Cards = new ViewModelCollection<CardViewModel>();
				foreach(Card tile in Model.Cards)
				{
					Cards.Add(new CardViewModel(tile));
				}
			}
		}

	}
}
