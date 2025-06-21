using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prog5_2c_2025.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Agregar swagger
builder.Services.AddControllers(); // Necesario para API controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Enfermedades API",
        Version = "v1",
        Description = "Obtener Enfermedades",
        Contact = new OpenApiContact
        {
            Name = "Jairo Zuniga",
            Email = "jzuniga@jairozuniga.com"
        }
    });


    // Configuración para incluir comentarios XML (opcional)
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    //c.DocInclusionPredicate((docName, description) =>
    //{
    //    return description.ActionDescriptor.RouteValues["controller"]
    //           .EndsWith("Api", StringComparison.OrdinalIgnoreCase);
    //});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = "api-docs"; // Opcional: cambiar la ruta por defecto
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers(); // Mapear tanto MVC como API controllers
app.MapDefaultControllerRoute(); // Para controladores MVC tradicionales

app.Run();
