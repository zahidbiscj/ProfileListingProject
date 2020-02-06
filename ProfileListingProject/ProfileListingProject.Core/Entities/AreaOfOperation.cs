namespace ProfileListingProject.Core.Entities
{
    public class AreaOfOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}