using DotNetEnv;
using OpenAI_API;
using OpenAI_API.Chat;

public class OpenAIApiHelper
{
    private readonly string _apiKey;
    private readonly OpenAIAPI _openAi;

    public OpenAIApiHelper()
    {
        Env.Load();

        _apiKey = Env.GetString("OPENAI_API_KEY");
        if (string.IsNullOrWhiteSpace(_apiKey))
            throw new ArgumentException("API key cannot be empty", nameof(_apiKey));

        _openAi = new OpenAIAPI(_apiKey);
    }


    public async Task<string> GenerateSummaryAsync(string noteContent)
    {
        try
        {
            var chatRequest = new ChatRequest
            {
                Model = "gpt-3.5-turbo",
                Temperature = 0.5,
                MaxTokens = 100,
                Messages = new[]
                {
                    new ChatMessage(ChatMessageRole.System,
                        "You are a helpful assistant that summarizes notes concisely."),
                    new ChatMessage(ChatMessageRole.User, $"Summarize this in 1-2 sentences:\n\n{noteContent}")
                }
            };

            var result = await _openAi.Chat.CreateChatCompletionAsync(chatRequest);

            return result?.Choices?[0]?.Message?.Content?.Trim() ?? string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"OpenAI API Error: {ex}");
            return $"Error generating summary: {ex.Message}";
        }
    }

    public async Task<bool> IsApiAvailable()
    {
        try
        {
            var models = await _openAi.Models.GetModelsAsync();
            return models?.Count > 0;
        }
        catch
        {
            return false;
        }
    }
}