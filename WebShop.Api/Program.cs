using WebShop.Api.Services;
using WebShop.Api.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllApp", policy =>
    {
        policy.AllowAnyOrigin()               
              .AllowAnyHeader()                     
              .AllowAnyMethod();                    
    });
});

builder.Services.AddControllers();

builder.Services.AddHttpClient("FakeApiHttpClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FakeApiUrl"]
        ?? throw new ArgumentNullException("FakeApiUrl"));
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllApp");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
