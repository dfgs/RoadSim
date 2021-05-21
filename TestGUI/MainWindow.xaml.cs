using RoadSimLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestGUI.ViewModels;

namespace TestGUI
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public static readonly DependencyProperty DeckProperty = DependencyProperty.Register("Deck", typeof(DeckViewModel), typeof(MainWindow));
		public DeckViewModel Deck
		{
			get { return (DeckViewModel)GetValue(DeckProperty); }
			set { SetValue(DeckProperty, value); }
		}

		public MainWindow()
		{
			InitializeComponent();

			Deck deck = new Deck();
			deck.Add(new Tile(1));
			deck.Add(new Tile(3));
			deck.Add(new Tile(7));
			deck.Add(new Tile(15));

			Deck = new DeckViewModel(deck);
			DataContext = Deck;
		}
	}
}
