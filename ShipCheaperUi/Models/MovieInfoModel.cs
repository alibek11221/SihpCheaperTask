using System.Runtime.Serialization;

namespace ShipCheaperUi.Models
{
    [DataContract]
    public class MovieModel
    {
        public string Title { get; set; }
        public string Runtime { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
    }
}