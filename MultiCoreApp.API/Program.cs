using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer;
using MultiCoreApp.DataAccessLayer.Repository;
using MultiCoreApp.DataAccessLayer.UnitOfWork;
using MultiCoreApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));

//Lifecycle ==> �li�kil kodun ya�am s�resi
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<MultiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"), sqlServerOptionsAction: sqloptions =>
    {
        sqloptions.EnableRetryOnFailure();
        sqloptions.MigrationsAssembly("MultiCoreApp.DataAccessLayer");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
