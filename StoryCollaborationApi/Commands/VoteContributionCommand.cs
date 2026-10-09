using MediatR;

namespace StoryCollaborationApi.Commands
{
    public class VoteContributionCommand : IRequest<bool>
    {
        public Guid ContributionId { get; set; }
        public Guid VoterId { get; set; }
        public int Value { get; set; }
    }
}