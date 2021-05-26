using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLib;

namespace TestGUI.ViewModels
{
	public class TilesViewModel : ViewModelCollection<TileViewModel>, IDropTarget
	{
		void IDropTarget.DragOver(IDropInfo dropInfo)
		{
			CardViewModel sourceItem = dropInfo.Data as CardViewModel;
			TileViewModel targetItem = dropInfo.TargetItem as TileViewModel;

			if (sourceItem == null || targetItem == null) return;

			if (targetItem.Model.Pattern != 0) return;
			
			dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
			dropInfo.Effects = DragDropEffects.Copy;
			
		}

		void IDropTarget.Drop(IDropInfo dropInfo)
		{
			CardViewModel sourceItem = dropInfo.Data as CardViewModel;
			TileViewModel targetItem = dropInfo.TargetItem as TileViewModel;

			targetItem.SetPattern(sourceItem.Model.Pattern);

		}

	}
}
