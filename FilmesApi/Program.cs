using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//--------------------------------------------------------------------------------------------

//Inicia a conexão com o banco de dados
builder.Services.AddDbContext<FilmeContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("FilmeConnection")));


// auto mapper serve para mapear um objeto para outro objeto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// NewtonsoftJson serve para resolver problemas de referência cíclica (looping infinito)
// recebe um objeto e transforma em um json
builder.Services.AddControllers().AddNewtonsoftJson();

//--------------------------------------------------------------------------------------------

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
