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
    // �[�J�̭��o�q�i�H�N�Ҧ��z�LEF Core�Ұ��檺�y�k�A���L��Console��
    option.EnableSensitiveDataLogging();
    // �]�i������
    option.LogTo(Console.WriteLine);
    // EnableSensitiveDataLogging()�O�_�ά����ӷP��T����k�A�}��EnableDetailedErrors�i�H��EF�o�����~�i�JTryCatch�϶��A�b�}�o�ɴ��ѧ�ԲӪ����~�T���C
    option.EnableDetailedErrors();
    // option.LogTo �O�bEF Core 5���X���s�\��A�i�H��²����A�a�h�w�q�n�O�����Ӹ`�A�Ҧp�G�����h�šB������m...���C
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
