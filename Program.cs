using CRUD_prosjekt.Data;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option => {
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
});
    

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IProjectRepository, ProjectRepository>(); 
builder.Services.AddScoped<IBookRepository , BookRepository>(); 

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => 
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
