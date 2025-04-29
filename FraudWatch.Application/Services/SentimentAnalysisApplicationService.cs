using FraudWatch.Application.Services.Interfaces;
using FraudWatch.Domain.Entities;
using Microsoft.ML;
using System.Globalization;
using System.Text;

namespace FraudWatch.Application.Services;

public class SentimentAnalysisApplicationService : ISentimentAnalysisApplicationService
{
    private readonly MLContext _mlContext;
    private ITransformer _model;

    public SentimentAnalysisApplicationService()
    {
        _mlContext = new MLContext();
        TrainModel();
    }

    private void TrainModel()
    {
        var trainingData = new List<SentimentData>
        {
            // Experiências positivas
            new SentimentData { Text = PreprocessText("Gostei muito!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Foi excelente!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Adorei o serviço!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Muito bom!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Ótimo atendimento!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Recomendo muito!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Fiquei muito satisfeito!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Excelente trabalho!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("Tudo perfeito!"), Label = "Positivo" },
            new SentimentData { Text = PreprocessText("O melhor atendimento que já tive!"), Label = "Positivo" },

            // Experiências negativas
            new SentimentData { Text = PreprocessText("Não gostei."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Foi ruim."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Péssimo atendimento."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Odiei o serviço."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Muito ruim."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Não recomendo."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Fiquei muito insatisfeito."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Foi uma experiência ruim."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("Não valeu a pena."), Label = "Negativo" },
            new SentimentData { Text = PreprocessText("O atendimento foi muito ruim."), Label = "Negativo" }
        };

        var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

        var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
            .Append(_mlContext.Transforms.NormalizeMinMax("Features"))
            .Append(_mlContext.Transforms.Conversion.MapValueToKey("Label"))
            .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        _model = pipeline.Fit(dataView);
    }

    public SentimentPrediction Predict(string text)
    {
        var processedText = PreprocessText(text);

        var predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);

        var prediction = predictionEngine.Predict(new SentimentData { Text = processedText });

        var maxScoreIndex = Array.IndexOf(prediction.Score, prediction.Score.Max());
        var labels = new[] { "Positivo", "Negativo" };
        prediction.PredictedLabel = labels[maxScoreIndex];

        return prediction;
    }

    private string PreprocessText(string text)
    {
        text = text.ToLower();

        text = new string(text
            .Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray());

        text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        text = string.Join(" ", text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        return text;
    }
}
