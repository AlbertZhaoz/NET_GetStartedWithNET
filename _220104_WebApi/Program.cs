using Zack.Commons;

    var builder = WebApplication.CreateBuilder(args);

//初始化DI容器 https://github/com/yangzhongke/NETBookMaterials/
var assemblies = ReflectionHelper.GetAllReferencedAssemblies();
// Controllers 直接就可以拿到服务
builder.Services.RunModuleInitializers(assemblies);

// Add services to the container.
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
