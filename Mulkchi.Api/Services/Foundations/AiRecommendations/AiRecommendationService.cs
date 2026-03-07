using Mulkchi.Api.Models.Foundations.AIs;
using Mulkchi.Api.Models.Foundations.AIs.Exceptions;
using Mulkchi.Api.Brokers.Storages;

namespace Mulkchi.Api.Services.Foundations.AiRecommendations;

public partial class AiRecommendationService : IAiRecommendationService
{
    private readonly IStorageBroker storageBroker;

    public AiRecommendationService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }

    public ValueTask<AiRecommendation> AddAiRecommendationAsync(AiRecommendation aiRecommendation) =>
        TryCatch(async () =>
        {
            ValidateAiRecommendationOnAdd(aiRecommendation);
            return await this.storageBroker.InsertAiRecommendationAsync(aiRecommendation);
        });

    public IQueryable<AiRecommendation> RetrieveAllAiRecommendations() =>
        TryCatch(() => this.storageBroker.SelectAllAiRecommendations());

    public ValueTask<AiRecommendation> RetrieveAiRecommendationByIdAsync(Guid aiRecommendationId) =>
        TryCatch(async () =>
        {
            ValidateAiRecommendationId(aiRecommendationId);
            AiRecommendation maybeAiRecommendation = await this.storageBroker.SelectAiRecommendationByIdAsync(aiRecommendationId);

            if (maybeAiRecommendation is null)
                throw new NotFoundAiRecommendationException(aiRecommendationId);

            return maybeAiRecommendation;
        });

    public ValueTask<AiRecommendation> ModifyAiRecommendationAsync(AiRecommendation aiRecommendation) =>
        TryCatch(async () =>
        {
            ValidateAiRecommendationOnModify(aiRecommendation);
            return await this.storageBroker.UpdateAiRecommendationAsync(aiRecommendation);
        });

    public ValueTask<AiRecommendation> RemoveAiRecommendationByIdAsync(Guid aiRecommendationId) =>
        TryCatch(async () =>
        {
            ValidateAiRecommendationId(aiRecommendationId);
            return await this.storageBroker.DeleteAiRecommendationByIdAsync(aiRecommendationId);
        });
}
