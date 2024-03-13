using StoreApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // for MVC 

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection")); // appsetting'ten tanımlanan con.str'yi alacak
});

var app = builder.Build();

// pipeline handles requests with routing and redirections
app.UseRouting();
app.UseHttpsRedirection();

app.MapControllerRoute( // default routing
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}" // id is optional
);

app.Run();
