using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using DataAccessLayer.UnitOfWorkFolder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategorieService, CategoriesService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<CategoryMapper>();
//builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<PostMapper>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<LikeMapper>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategorieService, CategoriesService>();
builder.Services.AddScoped<CategoryMapper>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();




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
