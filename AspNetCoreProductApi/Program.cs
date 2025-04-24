using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hostinh;
using Microsoft.EntityFrameworkCore;
using AspNetCoreProductApi.Data;

var builder = WebApplication.CreateBuilder(args);

//add services
builder.Services.AddContext<AppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplore();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();