using EcommerceDotNetPro.BusinessLogic.Authentication;
using EcommerceDotNetPro.BusinessLogic.JWT;
using EcommerceDotNetPro.DataLayer;
using EcommerceDotNetPro.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<LoginDll>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SignupService>();
builder.Services.AddScoped<Signupdll>();
var jwtSet = builder.Configuration.GetSection("jwt").Get<jwtsettings>();
Console.WriteLine($"Issuer: {jwtSet.Issuer}, Audience: {jwtSet.Audience}");
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<jwtsettings>>().Value);
builder.Services.AddScoped<TokenService>();
builder.Services.Configure<jwtsettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSet.Issuer,
        ValidAudience = jwtSet.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSet.Key))
    };
}) ;

builder.Services.AddMvc();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Session timeout
    options.Cookie.HttpOnly = true; // Makes cookie inaccessible to JavaScript
    options.Cookie.IsEssential = true; // Makes it required for the app to function
});


var app = builder.Build();

// session implementation





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSession();

app.MapGet("/", async context =>
{
    // Set session value
    context.Session.SetString("key", "B2A15D12E2164");

    // Retrieve session value
    var user = context.Session.GetString("key");
    await context.Response.WriteAsync($"sessionid, {user}!");
});





app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
    app.UseAuthorization();

app.UseEndpoints(endpoints =>
endpoints.MapControllers()
) ; 

app.UseAuthorization();

app.MapControllers();

app.Run();
