﻿namespace MicrosoftAzure.Storage.Data.Core.OpenAI
{
    public interface IOpenAIServiceCore
    {
        //Task<Response<ChatCompletions>> GenerateChatTextAsync(string searchText);
        Task<OpenAIOutputResponseModel> GenerateChatTextAsync(string searchText);
    }
}
