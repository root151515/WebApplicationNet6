using WebApplicationNet6.Class;
using WebApplicationNet6.Interface;
using WebApplicationNet6.Model;
using WebApplicationNet6.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service
builder.Services.AddDbContext<BlogContext>(option =>
{
    // 加入裡面這段可以將所有透過EF Core所執行的語法，都印到Console中
    option.EnableSensitiveDataLogging();
    // 也可替換成
    option.LogTo(Console.WriteLine);
    // EnableSensitiveDataLogging()是起用紀錄敏感資訊的方法，開啟EnableDetailedErrors可以讓EF發的錯誤進入TryCatch區塊，在開發時提供更詳細的錯誤訊息。
    option.EnableDetailedErrors();
    // option.LogTo 是在EF Core 5推出的新功能，可以更簡單明瞭地去定義要記錄的細節，例如：紀錄層級、紀錄位置...等。
    option.LogTo(Console.WriteLine, LogLevel.Information);
});
builder.Services.AddScoped<IScoped, SampleClass>();
builder.Services.AddSingleton<ISingleton, SampleClass>();
builder.Services.AddTransient<ITransient, SampleClass>();
builder.Services.AddScoped<SampleService>();


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
