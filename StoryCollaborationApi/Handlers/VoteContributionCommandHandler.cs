using MediatR;
using StoryCollaborationApi.Commands;
using StoryCollaborationApi.Interfaces;
using StoryCollaborationApi.Models;

namespace StoryCollaborationApi.Handlers
{
    public class VoteContributionCommandHandler : IRequestHandler<VoteContributionCommand, bool>
    {
        private readonly IStoryRepository _repository;

        public VoteContributionCommandHandler(IStoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(VoteContributionCommand request, CancellationToken cancellationToken)
        {
            var contribution = await _repository.GetContributionByIdAsync(request.ContributionId);

            if (contribution == null || contribution.Status != "Pending")
                return false;

            var vote = new Vote
            {
                ContributionId = request.ContributionId,
                VoterId = request.VoterId,
                Value = request.Value
            };

            await _repository.AddVoteAsync(vote);

            if (request.Value > 0)
                contribution.VotesUp++;
            else
                contribution.VotesDown++;

            if (contribution.VotesUp - contribution.VotesDown >= 5)
            {
                contribution.Status = "Accepted";
                contribution.PromotedAt = DateTime.UtcNow;

                var author = await _repository.GetUserByUsernameAsync(contribution.Author);
                if (author != null)
                {
                    author.Reputation += 10;
                    await _repository.UpdateUserAsync(author);
                }
            }

            await _repository.UpdateContributionAsync(contribution);
            return true;
        }
    }
}