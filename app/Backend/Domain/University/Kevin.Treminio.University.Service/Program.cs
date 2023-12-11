using Kevin.Treminio.University.Service.Application.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Http.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("UniversityConnection");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(o => o.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////

app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.ResgiterEndpoints();
app.UseSeedData();
app.UseAllowAllCORS();
app.Run();