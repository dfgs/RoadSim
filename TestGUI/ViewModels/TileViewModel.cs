using RoadSimLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLib;

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
			if (Model == null)
			{
				ImageSource = null;
				return;
			}

			
			ImageSource = $"/Images/Tile{Model.Pattern}.png";

			base.OnModelChanged(OldValue,NewValue);
		}

		
		public void SetPattern(int Pattern)
		{
			if (Model == null) return;
			Model.Pattern = Pattern;

			ImageSource = $"/Images/Tile{Model.Pattern}.png";
		}



	}
}
