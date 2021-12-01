using BlazorApp.Scheduler;
using Hangfire;
using Hangfire.MemoryStorage;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// HANGFIRE
builder.Services.AddHangfire(x => x.UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

IConfiguration configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");



// HANGFIRE
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    AppPath = "/",
    DashboardTitle = "Hangfire",
    Authorization = new[]
        {
                new HangfireCustomBasicAuthenticationFilter{
                    User = configuration.GetSection("HangfireSettings:UserName").Value,
                    Pass = configuration.GetSection("HangfireSettings:Password").Value
                }
            }
});

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

// HANGFIRE JOBS
RecurringJob.AddOrUpdate<MoveFilesScheduler>("Move Files", x => x.Execute(), "* * * * *");
RecurringJob.AddOrUpdate<JeevesScheduler>("Get Jeeves Projects", x => x.LoadProjects(), "* * * * *");

app.Run();


