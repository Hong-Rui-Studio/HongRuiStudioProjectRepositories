using Entity.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<MyContext>(opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DbCon")    
    )
);


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllerRoute(
        "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
