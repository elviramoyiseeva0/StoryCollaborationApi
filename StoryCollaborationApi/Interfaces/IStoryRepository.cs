using StoryCollaborationApi.Models;

namespace StoryCollaborationApi.Interfaces
{
    public interface IStoryRepository
    {
        Task<Contribution?> GetContributionByIdAsync(Guid id);
        Task AddVoteAsync(Vote vote);
        Task UpdateContributionAsync(Contribution contribution);
        Task<UserProfile?> GetUserByUsernameAsync(string username);
        Task UpdateUserAsync(UserProfile user);
    }
}