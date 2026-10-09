namespace StoryCollaborationApi.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public int Reputation { get; set; }
    }
}
