namespace StoryCollaborationApi.Models
{
    public class Contribution
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BranchId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; } 
        public string Status { get; set; } = "Pending";
        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        public DateTime? PromotedAt { get; set; }
    }
}
