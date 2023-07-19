using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using StoreAPI.Mapper;
using StoreAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AutoMapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Cors
builder.Services.AddCors();

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
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
builder.Services.AddScoped<IUserVoucherRepository, UserVoucherRepository>();
builder.Services.AddScoped<IOrderVoucherRepository, OrderVoucherRepository>();
builder.Services.AddScoped<IRecomenderRepository, RecomenderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


//Add NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;

//Blob Services
builder.Services.AddSingleton(u => new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount")));
builder.Services.AddSingleton<IBlobService, BlobService>();

//Authen
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(option => {
//        option.LoginPath = "/Auth/Login";
//        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
           new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
    });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
