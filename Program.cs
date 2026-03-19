using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//配置 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "我的第一个 Web API"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();         
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = "swagger";  // 设置根路径访问
    });
}
//异常处理中间件
//app.UseExceptionHandler("/Error");
//静态文件中间件
//app.UseStaticFiles();
//路由中间件
app.UseRouting();
//HTTPS 重定向
app.UseHttpsRedirection();
//授权中间件
app.UseAuthorization();
//终结点中间件
app.MapControllers();

app.Run();
