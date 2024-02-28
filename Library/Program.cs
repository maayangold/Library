using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data.Repositories;
using Solid.Data;
using Solid.Service;
using System.Text.Json.Serialization;
using Solid.Core;
using Library;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ginore cycle
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
//services and repo injection
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

//mapping
builder.Services.AddAutoMapper(typeof(MappingProfile),typeof(ApiMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//MiddleWare
app.UseShabbatCheck();

app.MapControllers();

app.Run();
