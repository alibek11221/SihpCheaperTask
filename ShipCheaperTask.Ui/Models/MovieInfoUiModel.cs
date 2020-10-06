using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ShipCheaperTask.Ui.Models
{
    public class MovieInfoUiModel
    {
        public string ImdbID { get; set; }
        public string MovieTitle { get; set; }
        public string Runtime { get; set; }
        public string Year { get; set; }
        public BitmapImage Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public bool IsFavorite { get; set; }
    }
}
