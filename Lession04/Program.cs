using Lession04.Services;  // Fixed typo from "Sevices" to "Services"

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Fixed the routing - removed duplicate "default" route and combined them
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LvsHome}/{action=LvsIndex}/{id?}");

app.MapControllerRoute(
    name: "books",
    pattern: "LvsBook/{action=Index}/{id?}",
    defaults: new { controller = "LvsBook" });

app.Run();