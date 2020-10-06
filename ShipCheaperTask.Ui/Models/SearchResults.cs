using Catel.Data;
using Catel.MVVM;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShipCheaperTask.Ui.Models
{
    public class SearchResults
    {

        public ObservableCollection<MovieInfoUiModel> Movies { get; set; }
    }
}
