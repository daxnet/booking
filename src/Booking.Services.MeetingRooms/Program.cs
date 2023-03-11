using Booking.Services.MeetingRooms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var authority = builder.Configuration["authority:url"];
        options.Authority = authority;
        options.Audience = "management";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("management.read", policy => policy.RequireClaim("scope", "management.read"));
    options.AddPolicy("management.create", policy => policy.RequireClaim("scope", "management.create"));
    options.AddPolicy("management.update", policy => policy.RequireClaim("scope", "management.update"));
    options.AddPolicy("management.delete", policy => policy.RequireClaim("scope", "management.delete"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MeetingRoomApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration["db:connectionString"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//static TokenValidationParameters CreateTokenValidationParameters() => new()
//{
//    ValidateIssuer = false,
//    ValidateAudience = false,
//    ValidateIssuerSigningKey = false,
//    SignatureValidator = delegate (string token, TokenValidationParameters parameters)
//    {
//        var jwt = new JwtSecurityToken(token);
//        return jwt;
//    },
//    RequireExpirationTime = true,
//    ValidateLifetime = true,
//    ClockSkew = TimeSpan.Zero,
//    RequireSignedTokens = false
//};

static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
{
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
    var builder = new ServiceCollection()
        .AddLogging()
        .AddMvc()
        .AddNewtonsoftJson()
        .Services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'

    return builder
        .GetRequiredService<IOptions<MvcOptions>>()
        .Value
        .InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>()
        .First();
}
