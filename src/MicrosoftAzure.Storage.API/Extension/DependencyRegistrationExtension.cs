
using MicrosoftAzure.Storage.Data.BusinessObject.FileShares;
using MicrosoftAzure.Storage.Data.BusinessObjects.Queue;
using MicrosoftAzure.Storage.Data.BusinessObjects.Table;
using MicrosoftAzure.Storage.Data.Core.FileShares;
using MicrosoftAzure.Storage.Data.Core.Queue;
using MicrosoftAzure.Storage.Data.Core.Table;

namespace MicrosoftAzure.API.Extension
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
          
            Services.AddTransient<IBlobServiceCore, BlobServiceCore>();
            Services.AddTransient<IBlobServiceBO, BlobServiceBO>();
            Services.AddTransient<IProcessStorageQueueMessageCore, ProcessStorageQueueMessageCore>();
            Services.AddTransient<IProcessStorageQueueMessageBO, ProcessStorageQueueMessageBO>();
            Services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
            Services.AddTransient<IProcessStorageTableCore, ProcessStorageTableCore>();
            Services.AddTransient<IProcessStorageTableBo, ProcessStorageTableBo>();
            Services.AddTransient<IFileSharesCore, FileSharesCore>();
            Services.AddTransient<IFileSharesBo, FileSharesBo>();
            return Services;
        }
        public static IServiceCollection AddApiDependencies(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            //Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("AzureAISearch"));
            Services.AddSwaggerGen();
            Services.AddControllers();
            Services.AddApplicationInsightsTelemetry();
            Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            return Services;
        }
    }
}
