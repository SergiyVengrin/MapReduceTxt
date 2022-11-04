using BLL.Services.Implementation;
using BLL.Services.Interfaces;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using ManagementNode;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IFileInfoRepository, FileInfoRepository>();
builder.Services.AddTransient<IManagementService, ManagementService>();
builder.Services.AddTransient<IFileInfoService, FileInfoService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.Run();