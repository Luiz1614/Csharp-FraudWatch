using FraudWatch.Domain.Entities;

namespace FraudWatch.Application.Services.Interfaces
{
    public interface ISentimentAnalysisApplicationService
    {
        SentimentPrediction Predict(string text);
    }
}