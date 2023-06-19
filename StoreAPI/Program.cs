using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Repository;
using StoreAPI.Mapper;
using StoreAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBabyRepository, BabyRepository>();
builder.Services.AddScoped<IProductBabyDevelopmentRepository, ProductBabyDevelopmentRepository>();
builder.Services.AddScoped<IMilestonesByMonthRepository, MilestonesByMonthRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBabyDevelopmentRepository, BabyDevelopmentRepository>();
builder.Services.AddScoped<IDevelopmentRepository, DevelopmentRepository>();
builder.Services.AddScoped<ITakeCareDevelopmentRepository, TakeCareDevelopmentRepository>();
builder.Services.AddScoped<IBabyTakeCareRepository, BabyTakeCareRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

//Add NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

//Blob Services
builder.Services.AddSingleton(u => new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount")));
builder.Services.AddSingleton<IBlobService, BlobService>();

//Authen
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Auth/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();