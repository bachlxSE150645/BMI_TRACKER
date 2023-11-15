
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:BMITracker"));

builder.Services.AddScoped<IUserRepository, userRepository>();
builder.Services.AddScoped<IIngredientRepository, ingredientRepository>();
builder.Services.AddScoped<IFoodRepository,foodRepository>();
builder.Services.AddScoped<IMenuRepository, menuRepository>();
builder.Services.AddScoped<ICategoryRepository, categoryRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IRoleRepository, roleRepository>();
builder.Services.AddScoped<IRecipeRepository, recipeRepository>();
builder.Services.AddScoped<IFeedbackRepository, feedbackRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IMessageRepository, messageRepository>();
builder.Services.AddScoped<IUserBodyMaxRepositorycs, userBodyMaxRepository>();
builder.Services.AddScoped<IServiceRepository, serviceReposiotry>();
builder.Services.AddScoped<IServiceTypeRepository, serviceTypeRepository>();
builder.Services.AddScoped<INotificationRepository, notificationRepository>();
builder.Services.AddScoped<ITrackFormRepository, trackFormRepository>();
builder.Services.AddScoped<IComplementRepository,ComplementRepository>();


builder.Services.AddAutoMapper(typeof(Program));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
