using Kevin.Treminio.University.Service.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddInfrastructure(o => o.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();


app.Run();