namespace HydroBookApi.Models
{
    public class Story
    {
        public long Id { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PublicationDate { get; set; }
        public string SourceUrl { get; set; }
        public string SourceName { get; set; }
    }
}