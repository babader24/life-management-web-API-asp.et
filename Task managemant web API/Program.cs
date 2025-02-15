using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Data;
using Task_managemant_web_API.Repository;
using Task_managemant_web_API.Repository.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(
			builder.Configuration.GetConnectionString("constr")));

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();

//Cros For All 
builder.Services.AddCors(op =>
{
	op.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
}
);


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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
