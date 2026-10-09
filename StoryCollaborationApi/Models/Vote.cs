namespace StoryCollaborationApi.Models
{
    public class Vote
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ContributionId { get; set; }
        public Guid VoterId { get; set; }
        public int Value { get; set; }
    }
}
