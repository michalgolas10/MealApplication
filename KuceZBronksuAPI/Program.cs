using KuceZBronksuAPIBLL.Models;
using KuceZBronksuAPIBLL.Services;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPI;

public class Program
{
	public static void Main(string[] args)
	{

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddDbContext<MealAppContext>(options =>
			options.UseSqlServer(builder.Configuration
			.GetConnectionString("DefaultConnection"))
		);

		builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		builder.Services.AddTransient<IReportManager, ReportManager>();
		builder.Services.AddAutoMapper(typeof(VisitedRecipeDTO), typeof(Program));
		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
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
	}
}