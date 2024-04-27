
var builder = WebApplication.CreateBuilder(args);

var aiOptions = new Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions();
aiOptions.EnableAdaptiveSampling = false;
aiOptions.EnableQuickPulseMetricStream = false;
builder.Services.AddApiDependencies();
builder.Services.AddServiceDependencies();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.Run();