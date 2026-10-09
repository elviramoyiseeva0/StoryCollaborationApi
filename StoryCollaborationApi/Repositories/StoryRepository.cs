using Microsoft.EntityFrameworkCore;
using StoryCollaborationApi.Data;
using StoryCollaborationApi.Interfaces;
using StoryCollaborationApi.Models;

namespace StoryCollaborationApi.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ApplicationContext _context;

        public StoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Contribution?> GetContributionByIdAsync(Guid id)
        {
            return await _context.Contributions.FindAsync(id);
        }

        public async Task AddVoteAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContributionAsync(Contribution contribution)
        {
            _context.Contributions.Update(contribution);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile?> GetUserByUsernameAsync(string username)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task UpdateUserAsync(UserProfile user)
        {
            _context.UserProfiles.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}