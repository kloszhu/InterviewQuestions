
using InterviewQuestions.BLL;
using InterviewQuestions.Migration;
using Mapster;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()
    // Nullvalue can not show.
    .AddNewtonsoftJson(options => {
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
// Add DbConnection Service
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//connect DB use SqlSugar
builder.Services.UseOrderDB_Mysql(builder.Configuration);
//create database.
builder.Services.UserOrderDB_Migration();
builder.Services.AddBLL();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
