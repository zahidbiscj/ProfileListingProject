namespace ProfileListingProject.Core.Entities
{
    public class ProductScreenshot
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public Product Product { get; set; }
    }
}