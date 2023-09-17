using LibraTech.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<LibratechContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("ConexaoPadrao"), new MySqlServerVersion(new Version(8, 0, 34))));
    builder.Services.AddControllers();    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
