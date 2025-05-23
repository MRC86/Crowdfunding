using Crowdfunding.Application;
using Crowdfunding.Infrastructure;
using Crowdfunding.Middleware;
using Crowdfunding.Share;
using Crowdfunding.Database;
using System.Reflection;
using Crowdfunding.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDataBaseServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddShareServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders(); // 把那些偷加的都幹掉

#region API Cors

// Allow Browser Call APIS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                .WithMethods("*")
                .WithHeaders("*");
        });
});

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
