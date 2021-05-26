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
	public class CardViewModel:ViewModel<Card>
	{

		public static readonly DependencyProperty RotateCommandProperty = DependencyProperty.Register("RotateCommand", typeof(ViewModelCommand), typeof(CardViewModel));
		public ViewModelCommand RotateCommand
		{
			get { return (ViewModelCommand)GetValue(RotateCommandProperty); }
			set { SetValue(RotateCommandProperty, value); }
		}


		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(CardViewModel));
		public string ImageSource
		{
			get { return (string)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}


		public CardViewModel():base()
		{
			RotateCommand = new ViewModelCommand(RotateCommandCanExecute, RotateCommandExecute);
		}

		

		public CardViewModel(Card Model) : base(Model)
		{
			RotateCommand = new ViewModelCommand(RotateCommandCanExecute, RotateCommandExecute);

		}
		protected override void OnModelChanged(Card OldValue, Card NewValue)
		{
			if (Model == null) ImageSource = null;
			else ImageSource = $"/Images/Tile{Model.Pattern}.png";

			
		}

		public void Rotate()
		{
			if (Model == null) return;
			Model.Rotate();
			ImageSource = $"/Images/Tile{Model.Pattern}.png";
		}


		private bool RotateCommandCanExecute(object arg)
		{
			return true;
		}

		private void RotateCommandExecute(object obj)
		{
			Rotate();
		}




	}
}
