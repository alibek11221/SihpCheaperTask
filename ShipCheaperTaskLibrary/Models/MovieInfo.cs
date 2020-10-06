using System.ComponentModel.DataAnnotations;

namespace ShipCheaperTaskLibrary.Models
{
    public class MovieInfoDbo
    {
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Runtime { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
    }
}