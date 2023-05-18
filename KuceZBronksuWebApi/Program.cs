using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuBLL.Services;
using KuceZBronksuWebApi.Services.IServices;
using KuceZBronksuWebApi.Services;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<ITimeService, TimeService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddScoped<IRaportService, RaportService>();
builder.Services.AddAutoMapper(typeof(RecipeViewModel), typeof(Program));
builder.Services.AddAutoMapper(typeof(EditAndCreateViewModel), typeof(Program));
builder.Services.AddAutoMapper(typeof(Recipe), typeof(Program));
builder.Services.AddAutoMapper(typeof(User), typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
