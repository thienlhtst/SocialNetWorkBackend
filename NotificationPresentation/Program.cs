using ConsumerViewModel;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotificationPresentation.Consumers;
using NotificationPresentation.Hubs;
using NotificationPresentation.Infrastucture;
using NotificationPresentation.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NotificationDbSC");
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddSignalR(); // Thêm SignalR

// Add services to the container.
builder.Services.AddTransient<INotificationService, NotificationService>();
//
builder.Services.AddMassTransit(x =>
{
    // x.AddConsumer<UserFollowedConsumer>(); // Đăng ký Consumer
    //request
    //request
    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    var asb = typeof(Program).Assembly;
    x.AddConsumers(asb);
    x.AddSagaStateMachines(asb);
    x.AddSagas(asb);
    x.AddActivities(asb);
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("localhost", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });
        cfg.ConfigureEndpoints(ctx);
    });
});
////
///

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsPolicy");
app.UseWebSockets();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger T2Pro V1");
});
app.UseSwagger();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", () => "MassTransit with RabbitMQ on Docker!"); ;
app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub"); // Map SignalR Hub

app.Run();