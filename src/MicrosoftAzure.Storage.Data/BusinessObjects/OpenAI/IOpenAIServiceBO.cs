namespace MicrosoftAzure.Storage.Data.BusinessObject.OpenAI
{
    public interface IOpenAIServiceBO
    {
        //Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText);
        Task<OpenAIOutputResponseModel> GenerateChatTextAsync(string searchText);
    }
}
