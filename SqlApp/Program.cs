using SqlApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
builder.Services.AddTransient<CourseService>();

string appConfigAccessKey = "Endpoint=https://webappconfigalexei.azconfig.io;Id=q0Hu;Secret=mHtWYL4j6A3sy7dOg9ASoFIPZXQcveAhi8tSDa+H76A=";
builder.Configuration.AddAzureAppConfiguration(appConfigAccessKey);


var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
