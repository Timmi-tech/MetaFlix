using MetaFlix.Domain.Entities.Models;

namespace MetaFlix.Domain.Contracts
{
    public interface IRatingRepository
    {
        Task<Rating?> GetUserRatingAsync(Guid videoId, string userId, bool trackChanges);
        void AddRatingAsync(Rating rating);
        void UpdateRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsByVideoIdAsync(Guid videoId, bool trackChanges);
    }
}