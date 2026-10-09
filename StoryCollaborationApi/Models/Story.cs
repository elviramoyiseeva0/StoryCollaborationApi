namespace StoryCollaborationApi.Models
{
    public class Story
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid RootBranchId { get; set; }
    }
}
