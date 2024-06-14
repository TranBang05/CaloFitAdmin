using AdminApi.Dto.Mapper;
using AdminApi.Models;
using AdminApi.Service;
using AdminApi.Service.Impl;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt => opt
    .Select()
    .Expand()
    .Filter()
    .OrderBy()
    .Count()
    .SetMaxTop(100)


    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddDbContext<CalofitDBContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("LoadDb")));

builder.Services.AddAutoMapper(typeof(MyMapper).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
