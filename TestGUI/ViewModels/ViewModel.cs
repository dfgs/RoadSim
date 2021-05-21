using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestGUI.ViewModels
{
	public class ViewModel<T> : DependencyObject
	{

		public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(T), typeof(ViewModel<T>),new FrameworkPropertyMetadata(null,ModelPropertyChanged));
		public T Model
		{
			get { return (T)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		public ViewModel()
		{
		}
		public ViewModel(T Model)
		{
			this.Model = Model;
		}


		private static void ModelPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			((ViewModel<T>)obj).OnModelChanged((T)e.OldValue,(T)e.NewValue);
		}

		protected virtual void OnModelChanged(T OldValue,T NewValue)
		{

		}



	}
}
