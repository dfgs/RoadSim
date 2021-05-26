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


		public static readonly DependencyProperty InstanceProperty = DependencyProperty.Register("Instance", typeof(InstanceViewModel), typeof(MainWindow));
		public InstanceViewModel Instance
		{
			get { return (InstanceViewModel)GetValue(InstanceProperty); }
			set { SetValue(InstanceProperty, value); }
		}


		public MainWindow()
		{
			InitializeComponent();



			Instance instance = new Instance();
			instance.Deck = new Deck();
			instance.Deck.Add(new Card(1));
			instance.Deck.Add(new Card(3));
			instance.Deck.Add(new Card(7));
			instance.Deck.Add(new Card(15));

			instance.Map = new Map(10, 10);

			Instance = new InstanceViewModel(instance);
			
			DataContext = Instance;
		}

		


	}
}
