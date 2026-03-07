using Mulkchi.Api.Models.Foundations.AIs;

namespace Mulkchi.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<AiRecommendation> InsertAiRecommendationAsync(AiRecommendation aiRecommendation);
    IQueryable<AiRecommendation> SelectAllAiRecommendations();
    ValueTask<AiRecommendation> SelectAiRecommendationByIdAsync(Guid aiRecommendationId);
    ValueTask<AiRecommendation> UpdateAiRecommendationAsync(AiRecommendation aiRecommendation);
    ValueTask<AiRecommendation> DeleteAiRecommendationByIdAsync(Guid aiRecommendationId);
}
