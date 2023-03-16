using Microsoft.EntityFrameworkCore;
using TODO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContextFactory(ApplicationDbContextFactory);
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>options.UseSqlite("Data Source=sqlite3.db"),
    optionsLifetime: ServiceLifetime.Singleton
);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options=>{
        options.TokenValidationParameters=new TokenValidationParameters{
            ValidateIssuer=true,
            ValidIssuer=AuthOptions.ISSUER,
            ValidAudience=AuthOptions.AUDIENCE,
            ValidateLifetime=true,
            IssuerSigningKey=AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey=true
        };
    }
);
builder.Services.AddIdentityCore<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a jwt token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddHttpContextAccessor();
// builder.Services.AddSwaggerGen(option=>{
//     option.SwaggerDoc("v1",new OpenApiInfo{});
//     option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme{
//         In=ParameterLocation.Header,
//         Description="Please enter a valid token",
//         Name="Authorization",
//         Type=SecuritySchemeType.Http,
//         BearerFormat="JWT",
//         Scheme="Bearer"
//     });
//     option.AddSecurityRequirement(new OpenApiSecurityRequirement{
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference=new OpenApiReference
//                 {
//                     Type=ReferenceType.SecurityScheme,
//                     Id="Bearer"
//                 }
//             },
//             new string[]{}
//         }
//     });
// });
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
