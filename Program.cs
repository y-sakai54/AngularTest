using AngularTest.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(opt =>
    opt.UseInMemoryDatabase("MyDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    // テスト用に初期データ入れる
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();

    db.Rankings.Add(new Ranking { Id = 1, Rank = 1, Name = "YASU_01", Score = 1000 });
    db.Rankings.Add(new Ranking { Id = 2, Rank = 2, Name = "YASU_02", Score = 900 });
    db.Rankings.Add(new Ranking { Id = 3, Rank = 3, Name = "YASU_03", Score = 800 });
    db.Rankings.Add(new Ranking { Id = 4, Rank = 4, Name = "YASU_04", Score = 700 });
    db.Rankings.Add(new Ranking { Id = 5, Rank = 5, Name = "YASU_05", Score = 600 });
    db.Rankings.Add(new Ranking { Id = 6, Rank = 6, Name = "YASU_06", Score = 500 });
    db.SaveChanges();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
